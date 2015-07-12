using System;
using Newtonsoft.Json;

namespace InfoDisplay.Common.Util.Json
{
    /// <summary>
    /// Converts a JSON object to the specified concrete type.
    /// </summary>
    /// <remarks>Intended to handle de-serialization of interfaces.</remarks>
    /// <typeparam name="TConcrete">Concrete type to convert to.</typeparam>
    public class ConcreteTypeConverter<TConcrete> : JsonConverter
    {
        /// <see cref="JsonConverter.WriteJson"/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <see cref="JsonConverter.ReadJson"/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TConcrete>(reader);
        }

        /// <see cref="JsonConverter.CanConvert"/>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
