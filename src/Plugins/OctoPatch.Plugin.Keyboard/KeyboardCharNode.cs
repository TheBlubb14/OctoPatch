using OctoPatch.ContentTypes;
using OctoPatch.Descriptions;
using System;

namespace OctoPatch.Plugin.Keyboard
{
    public sealed class KeyboardCharNode : AttachedNode<EmptyConfiguration, EmptyEnvironment, KeyboardNode>
    {
        /// <summary>
        /// Description of the node
        /// </summary>
        public static NodeDescription NodeDescription => 
            AttachedNodeDescription.CreateAttached<KeyboardCharNode, KeyboardNode>(
                Guid.Parse(KeyboardPlugin.PluginId),
                "Keyboard Char",
                "Blabla")
            .AddOutputDescription(KeyCharPressedOutputDescription)
            .AddOutputDescription(KeyCharReleasedOutputDescription);

        /// <summary>
        /// Description of the keyboard char pressed output connector
        /// </summary>
        public static ConnectorDescription KeyCharPressedOutputDescription => new ConnectorDescription(
            "KeyCharPressedOutput", "key char pressed", "Key char pressed output signal",
            ComplexContentType.Create<char>(Guid.Parse(KeyboardPlugin.PluginId)));

        /// <summary>
        /// Description of the keyboard char released output connector
        /// </summary>
        public static ConnectorDescription KeyCharReleasedOutputDescription => new ConnectorDescription(
            "KeyCharReleasedOutput", "key char released", "Key char released output signal",
            ComplexContentType.Create<char>(Guid.Parse(KeyboardPlugin.PluginId)));

        protected override EmptyConfiguration DefaultConfiguration => new EmptyConfiguration();

        private readonly KeyboardNode _node;
        private readonly IOutputConnectorHandler _charPressedOutputConnector;
        private readonly IOutputConnectorHandler _charReleasedOutputConnector;

        public KeyboardCharNode(Guid nodeId, KeyboardNode parentNode)
            : base(nodeId, parentNode)
        {
            _node = parentNode;
            _node._hook.KeyboardPressed += Hook_KeyboardPressed;

            _charPressedOutputConnector = RegisterOutputConnector(KeyCharPressedOutputDescription);
            _charReleasedOutputConnector = RegisterOutputConnector(KeyCharReleasedOutputDescription);
        }

        protected override void OnDispose()
        {
            _node._hook.KeyboardPressed -= Hook_KeyboardPressed;
            base.OnDispose();
        }

        private void Hook_KeyboardPressed(object sender, GlobalKeyboardHook.GlobalKeyboardHookEventArgs e)
        {
            var c = _node._keyboard.GetCharFromVirtualKeyCode((uint)e.KeyboardData.VirtualCode);
            switch (e.KeyboardState)
            {
                case GlobalKeyboardHook.KeyboardState.KeyDown:
                case GlobalKeyboardHook.KeyboardState.SysKeyDown:
                    _charPressedOutputConnector.Send(c);
                    break;

                case GlobalKeyboardHook.KeyboardState.KeyUp:
                case GlobalKeyboardHook.KeyboardState.SysKeyUp:
                    _charReleasedOutputConnector.Send(c);
                    break;
            }
        }
    }
}
