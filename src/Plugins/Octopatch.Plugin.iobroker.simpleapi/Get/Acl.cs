using Newtonsoft.Json;

namespace Octopatch.Plugin.IoBroker.SimpleApi.Get
{
    internal class Acl
    {
        [JsonProperty("object")]
        public int Object { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("ownerGroup")]
        public string OwnerGroup { get; set; }
    }
}
