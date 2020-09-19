using Octopatch.Plugin.IoBroker.SimpleApi.Get;
using OctoPatch;
using System;

namespace Octopatch.Plugin.IoBroker.SimpleApi
{
    public sealed class SimpleApiPlugin : OctoPatch.Server.Plugin
    {
        internal const string PluginId = "{F5162245-4410-406A-B622-A0D1BBF61BCC}";

        public override Guid Id => Guid.Parse(PluginId);

        public override string Name => "ioBroker SimpleApi";

        public override string Description => "Adds nodes to communicate with the simple-api adapter in ioBroker";

        public override Version Version => new Version(0, 0, 1);

        public SimpleApiPlugin()
        {
            RegisterNode<GetNode>(GetNode.NodeDescription);
            RegisterNode<GetNode>(IoBrokerEnvironmentNode.NodeDescription);
        }

        protected override IAdapter OnCreateAdapter(Type type)
        {
            return null;
        }
    }
}
