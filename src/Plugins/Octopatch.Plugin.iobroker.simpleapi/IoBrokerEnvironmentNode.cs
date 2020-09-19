using OctoPatch;
using OctoPatch.Descriptions;
using System;

namespace Octopatch.Plugin.IoBroker.SimpleApi
{
    public sealed class IoBrokerEnvironmentNodeConfiguration : IConfiguration
    {
        public Uri SimpleApiUri { get; set; }

        public IoBrokerEnvironmentNodeConfiguration(Uri simpleApiUri)
        {
            SimpleApiUri = simpleApiUri;
        }
    }

    public sealed class IoBrokerEnvironmentNode : Node<IoBrokerEnvironmentNodeConfiguration, IoBrokerEnvironment>
    {
        public static NodeDescription NodeDescription => CommonNodeDescription.Create<IoBrokerEnvironmentNode>(
            Guid.Parse(SimpleApiPlugin.PluginId),
            "simple-api Environment",
            "Gets the current value of the specified state");

        protected override IoBrokerEnvironmentNodeConfiguration DefaultConfiguration =>
            new IoBrokerEnvironmentNodeConfiguration(new Uri("http://raspberrypi:8087"));

        private IoBrokerEnvironmentNode(Guid id) : base(id)
        {
            ConfigurationChanged += IoBrokerEnvironmentNode_ConfigurationChanged;
        }

        private void IoBrokerEnvironmentNode_ConfigurationChanged(INode sender, string args)
        {
            UpdateEnvironment(new IoBrokerEnvironment()
            {
                SimpleApiUri = Configuration.SimpleApiUri
            });
        }
    }
}
