using System;
using Newtonsoft.Json;

namespace InfoDisplay.Common.Util
{
    public class UnixDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var timestamp = serializer.Deserialize<int>(reader);
            return DateTimeExtensions.FromUnixTimestamp(timestamp);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
