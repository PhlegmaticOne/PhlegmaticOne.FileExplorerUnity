using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Properties.Views
{
    internal sealed class PropertiesViewModel : ViewModelBase
    {
        public PropertiesViewModel(Dictionary<string, string> properties)
        {
            Properties = properties;
        }

        public Dictionary<string, string> Properties { get; }
    }
}