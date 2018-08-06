using System;
using System.Collections.Generic;
using RestSharp;
using Typeform.Dotnet.Core;
using Typeform.Dotnet.Data;

namespace Typeform.Dotnet.Clients
{
    public class ResponsesApiClient : Client
    {
        private const string TypeformResponseApiBaseUrl = "https://api.typeform.com/";

        private const string FormResource = "forms/{formId}/responses";

        // Filtering Parameter Names
        private const string SinceFilterName = "since";
        private const string UntilFilterName = "until";
        private const string OffsetFilterName = "offset";
        private const string LimitFilterName = "page_size";
        private const string OrderByName = "sort_by";

        public string FormId { get; }

        public ResponsesApiClient(Authentication authentication, string formId) : base(TypeformResponseApiBaseUrl, FormResource, authentication)
        {
            if (string.IsNullOrEmpty(formId))
                throw new ArgumentNullException(nameof(formId));

            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));

            FormId = formId.Trim();
        }

        public ResponsesApiClient(string typeformApiUrl, Authentication authentication, string formId)
            : base(
                string.IsNullOrEmpty(typeformApiUrl) ? TypeformApiBaseUrl : typeformApiUrl, FormResource, authentication
            )
        {
            if (string.IsNullOrEmpty(formId))
                throw new ArgumentNullException(nameof(formId));

            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));

            FormId = formId.Trim();
        }

        public ApiResponses GetFormResponses(DateTimeOffset? resultsSinceDate = null, DateTimeOffset? resultsUntilDate = null, int resultsOffset = 0, int resultsLimit = 0)
        {
            var parameters = new Dictionary<string, string>();
            
            // Date Filters
            if (resultsSinceDate != null)
                parameters.Add(SinceFilterName, resultsSinceDate.Value.ToUnixTimeSeconds().ToString());

            if (resultsUntilDate != null)
                parameters.Add(UntilFilterName, resultsUntilDate.Value.ToUnixTimeSeconds().ToString());

            // Paging Options
            if (resultsOffset > 0)
                parameters.Add(OffsetFilterName, resultsOffset.ToString());

            if (resultsLimit > 0)
                parameters.Add(LimitFilterName, resultsLimit.ToString());

            parameters.Add(OrderByName, "submitted_at");

            var result = Get<ApiResponses>(null, parameters, formId: FormId, jsonContentType: false);

            return result.Result;
        }


        protected override IRestClient BuildClient()
        {
            var client = new RestClient(Url)
            {
                Authenticator = new AccessTokenAuthenticator("authorization", $"bearer {Auth.ApiKey}")
            };
            
            return client;
        }
    }
}