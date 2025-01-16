using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties
{
    internal sealed class PropertiesPopupViewModel : PopupViewModel
    {
        public PropertiesPopupViewModel(Dictionary<string, string> properties)
        {
            Properties = properties.Select(x => new PropertyViewModel(x.Key, x.Value)).ToArray();
        }

        public PropertyViewModel[] Properties { get; }
    }
}