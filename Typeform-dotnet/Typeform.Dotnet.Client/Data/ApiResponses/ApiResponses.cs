using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Typeform.Dotnet.Data
{
    public class ApiResponses
    {
        public long TotalItems { get; set; }
        public int PageCount { get; set; }
        public List<ApiResponseItem> Items { get; set; }
    }
}