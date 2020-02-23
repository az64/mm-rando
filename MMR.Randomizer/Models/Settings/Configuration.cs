using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMR.Randomizer.Models.Settings
{
    public class Configuration
    {
        public GameplaySettings GameplaySettings { get; set; }
        public CosmeticSettings CosmeticSettings { get; set; }
        public OutputSettings OutputSettings { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, _jsonSerializerSettings);
        }

        public static Configuration FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Configuration>(json, _jsonSerializerSettings);
        }

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new WritablePropertiesOnlyResolver(),
            NullValueHandling = NullValueHandling.Ignore,
        };

        static Configuration()
        {
            _jsonSerializerSettings.Converters.Add(new StringEnumConverter());
        }
    }

    class WritablePropertiesOnlyResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => p.Writable).ToList();
        }
    }
}
