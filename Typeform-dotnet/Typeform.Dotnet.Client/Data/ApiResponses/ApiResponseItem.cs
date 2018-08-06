using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Dotnet.Data
{
    public class ApiResponseItem
    {
        [JsonProperty("landing_id")]
        public string LandingId { get; set; }
        public string Token { get; set; }
        [JsonProperty("landed_at")]
        public string LandedAt { get; set; }
        [JsonProperty("submitted_at")]
        public DateTime SubmittedAt { get; set; }
        public List<Answer> Answers { get; set; }
        public Dictionary<string, string> Hidden { get; set; }
    }
}