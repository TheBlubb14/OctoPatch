﻿using Newtonsoft.Json;
using OctoPatch;
using OctoPatch.ContentTypes;
using OctoPatch.Descriptions;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Octopatch.Plugin.IoBroker.SimpleApi.Get
{
    public sealed class GetNode : Node<GetNodeConfiguration, IoBrokerEnvironment>
    {
        public static NodeDescription NodeDescription => CommonNodeDescription.Create<GetNode>(
            Guid.Parse(SimpleApiPlugin.PluginId),
            "Get",
            "Gets the current value of the specified state")
            .AddInputDescription(GetInputDescription)
            .AddOutputDescription(GetOutputDescription);

        public static ConnectorDescription GetInputDescription => new ConnectorDescription(
            "GetInput", "Any input value to trigger output", "When input received the node will output the current value of the specified state", new AllContentType());

        public static ConnectorDescription GetOutputDescription => new ConnectorDescription(
            "GetOutput", "State Value", "Gets the current value of the specified state",
            ComplexContentType.Create<string>(Guid.Parse(SimpleApiPlugin.PluginId)));

        public const string RequestPath = "get";

        protected override GetNodeConfiguration DefaultConfiguration => new GetNodeConfiguration();

        private readonly HttpClient http;
        private readonly IOutputConnectorHandler outputConnector;
        private GetNodeConfiguration configuration;

        public GetNode(Guid id) : base(id)
        {
            http = new HttpClient();

            RegisterInputConnector(GetInputDescription).HandleRaw(HandleMessage);
            outputConnector = RegisterOutputConnector(GetOutputDescription);
        }

        protected override Task OnInitialize(GetNodeConfiguration configuration, CancellationToken cancellationToken)
        {
            //this.configuration = configuration;
            this.configuration = new GetNodeConfiguration() { StateId = "zigbee.0.00158d00036bfd0e.humidity" };
            UpdateEnvironment(new IoBrokerEnvironment()
            {
                SimpleApiUri = new Uri("http://raspberrypi:8087")
            });
            return base.OnInitialize(configuration, cancellationToken);
        }

        private async void HandleMessage(Message message)
        {
            if (State != NodeState.Running)
                return;

            if (configuration?.StateId is null)
                return;

            var value = await http.GetStringAsync(new Uri(Environment.SimpleApiUri, $"{RequestPath}/{configuration.StateId}"));
            outputConnector.Send(JsonConvert.DeserializeObject<ObjectState>(value));
        }

        protected override void OnDispose()
        {
            http.Dispose();
            base.OnDispose();
        }
    }
}
