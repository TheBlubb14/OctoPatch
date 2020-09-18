using OctoPatch;
using System;

namespace Octopatch.Plugin.IoBroker.SimpleApi.Get
{
    public sealed class IoBrokerEnvironment : IEnvironment
    {
        /// <summary>
        /// The uri to the ioBroker instance
        /// </summary>
        public Uri SimpleApiUri { get; set; }
    }
}
