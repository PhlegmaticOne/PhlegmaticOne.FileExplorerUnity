using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Views
{
    internal sealed class PropertiesPopupViewModel : PopupViewModel
    {
        public PropertiesPopupViewModel(Dictionary<string, string> properties)
        {
            Properties = properties;
        }

        public Dictionary<string, string> Properties { get; }
    }
}