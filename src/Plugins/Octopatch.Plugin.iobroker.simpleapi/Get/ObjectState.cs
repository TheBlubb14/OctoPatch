using Newtonsoft.Json;

namespace Octopatch.Plugin.IoBroker.SimpleApi.Get
{
    internal struct ObjectState
    {
        [JsonProperty("val")]
        public string Val { get; set; }

        [JsonProperty("ack")]
        public bool Ack { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("q")]
        public int Q { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("lc")]
        public long Lc { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("common")]
        public Common Common { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("acl")]
        public Acl Acl { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
