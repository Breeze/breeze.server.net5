using System;
using Newtonsoft.Json;
using System.Xml;

namespace Breeze.ContextProvider
{

    // http://www.w3.org/TR/xmlschema-2/#duration
    public class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
#if DNX451
            throw new NotImplementedException("XML conversion not supported in dnx451");
#else
            var ts = (TimeSpan)value;
            var tsString = XmlConvert.ToString(ts);
            serializer.Serialize(writer, tsString);
#endif
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
#if DNX451
            throw new NotImplementedException("XML conversion not supported in dnx451");
#else
            var value = serializer.Deserialize<String>(reader);
            return XmlConvert.ToTimeSpan(value);
#endif
        }

        public override bool CanConvert(Type objectType)
        {
#if DNX451
            return false;
#else
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
#endif
        }
      }
    }
