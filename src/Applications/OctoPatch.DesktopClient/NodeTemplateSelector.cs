using System.Windows;
using System.Windows.Controls;
using OctoPatch.DesktopClient.Models;

namespace OctoPatch.DesktopClient
{
    public sealed class NodeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MidiDeviceTemplate { get; set; }

        public DataTemplate RestGetTemplate { get; set; }

        public DataTemplate KeyboardStringTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MidiDeviceModel)
            {
                return MidiDeviceTemplate;
            }
            else if(item is RestGetModel)
            {
                return RestGetTemplate;
            }
            else if (item is KeyboardStringModel)
            {
                return KeyboardStringTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
