using OctoPatch;

namespace Octopatch.Plugin.IoBroker.SimpleApi.Get
{
    public sealed class GetNodeConfiguration : IConfiguration
    {
        /// <summary>
        /// The id for which state we want to get a value
        /// </summary>
        public string StateId { get; set; }
    }
}
