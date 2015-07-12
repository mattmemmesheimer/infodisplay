using System;
using Newtonsoft.Json;

namespace InfoDisplay.Common.Util.Json
{
    /// <summary>
    /// Converts between an integer Unix timestamp and <see cref="DateTime" />.
    /// </summary>
    public class UnixDateTimeConverter : JsonConverter
    {
        /// <see cref="JsonConverter.WriteJson"/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <see cref="JsonConverter.ReadJson"/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var timestamp = serializer.Deserialize<int>(reader);
            return DateTimeExtensions.FromUnixTimestamp(timestamp);
        }

        /// <see cref="JsonConverter.CanConvert"/>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
