using OctoPatch.ContentTypes;
using OctoPatch.Descriptions;
using System;

namespace OctoPatch.Plugin.Keyboard
{
    public sealed class KeyboardStringNode : AttachedNode<KeyboardStringConfiguration, EmptyEnvironment, KeyboardNode>
    {
        /// <summary>
        /// Description of the node
        /// </summary>
        public static NodeDescription NodeDescription =>
            AttachedNodeDescription.CreateAttached<KeyboardStringNode, KeyboardNode>(
                Guid.Parse(KeyboardPlugin.PluginId),
                "Keyboard String",
                "Blabla")
            .AddOutputDescription(KeyStringPressedOutputDescription)
            .AddOutputDescription(KeyStringReleasedOutputDescription);

        /// <summary>
        /// Description of the keyboard string pressed output connector
        /// </summary>
        public static ConnectorDescription KeyStringPressedOutputDescription => new ConnectorDescription(
            "KeyStringPressedOutput", "key string pressed", "Key char pressed output signal",
            ComplexContentType.Create<string>(Guid.Parse(KeyboardPlugin.PluginId)));

        /// <summary>
        /// Description of the keyboard string released output connector
        /// </summary>
        public static ConnectorDescription KeyStringReleasedOutputDescription => new ConnectorDescription(
            "KeyStringReleasedOutput", "key string released", "Key char released output signal",
            ComplexContentType.Create<string>(Guid.Parse(KeyboardPlugin.PluginId)));

        protected override KeyboardStringConfiguration DefaultConfiguration => new KeyboardStringConfiguration();

        private readonly KeyboardNode _node;
        private readonly IOutputConnectorHandler _charPressedOutputConnector;
        private readonly IOutputConnectorHandler _charReleasedOutputConnector;

        public KeyboardStringNode(Guid nodeId, KeyboardNode parentNode)
            : base(nodeId, parentNode)
        {
            _node = parentNode;
            _node._hook.KeyboardPressed += Hook_KeyboardPressed;

            _charPressedOutputConnector = RegisterOutputConnector(KeyStringPressedOutputDescription);
            _charReleasedOutputConnector = RegisterOutputConnector(KeyStringReleasedOutputDescription);
        }

        protected override void OnDispose()
        {
            _node._hook.KeyboardPressed -= Hook_KeyboardPressed;
            base.OnDispose();
        }

        private void Hook_KeyboardPressed(object sender, GlobalKeyboardHook.GlobalKeyboardHookEventArgs e)
        {
            var s = _node._keyboard.GetUnicodeFromVirtualKeyCode((uint)e.KeyboardData.VirtualCode);

            if (Configuration.IgnoreNotPrintable && string.IsNullOrWhiteSpace(s))
                return;

            switch (e.KeyboardState)
            {
                case GlobalKeyboardHook.KeyboardState.KeyDown:
                case GlobalKeyboardHook.KeyboardState.SysKeyDown:
                    _charPressedOutputConnector.Send(new StringMessage(s));
                    break;

                case GlobalKeyboardHook.KeyboardState.KeyUp:
                case GlobalKeyboardHook.KeyboardState.SysKeyUp:
                    _charReleasedOutputConnector.Send(new StringMessage(s));
                    break;
            }
        }
    }
}
