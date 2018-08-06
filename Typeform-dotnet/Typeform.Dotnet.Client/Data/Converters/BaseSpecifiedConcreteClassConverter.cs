using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Typeform.Dotnet.Data
{
    public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Answer).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    public class AnswerConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Answer));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var type = jo["type"].Value<string>();
            switch (type)
            {
                case "text":
                    return JsonConvert.DeserializeObject<AnswerLongText>(jo.ToString(), SpecifiedSubclassConversion);
                case "choice":
                    return JsonConvert.DeserializeObject<AnswerChoice>(jo.ToString(), SpecifiedSubclassConversion);
                case "boolean":
                    return JsonConvert.DeserializeObject<AnswerBoolean>(jo.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new NotImplementedException($"This type not supported '{type}'");
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }
    }
}