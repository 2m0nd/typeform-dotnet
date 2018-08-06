using Newtonsoft.Json;

namespace Typeform.Dotnet.Data
{
    [JsonConverter(typeof(AnswerConverter))]
    public abstract class Answer
    {
        public Field Field { get; set; }
        public string Type { get; set; }
        public abstract string GetValue();
    }
}