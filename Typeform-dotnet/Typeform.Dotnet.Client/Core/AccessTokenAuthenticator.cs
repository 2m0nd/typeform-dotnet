using RestSharp;
using RestSharp.Authenticators;

namespace Typeform.Dotnet.Core
{
    public class AccessTokenAuthenticator : IAuthenticator
    {
        private readonly string _apiKeyName;
        private readonly string _apiKeyValue;

        public AccessTokenAuthenticator(string keyName, string keyValue)
        {
            _apiKeyName = keyName;
            _apiKeyValue = keyValue;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader(_apiKeyName, _apiKeyValue);
        }
    }
}