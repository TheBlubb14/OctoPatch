using Newtonsoft.Json;

namespace Octopatch.Plugin.IoBroker.SimpleApi.Get
{
    internal class Common
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }

        [JsonProperty("write")]
        public bool Write { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
