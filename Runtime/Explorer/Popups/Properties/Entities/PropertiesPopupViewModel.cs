using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertiesPopupViewModel : PopupViewModel
    {
        public PropertiesPopupViewModel(IPopupProvider popupProvider) : base(popupProvider)
        {
            Properties = new ReactiveCollection<PropertyViewModel>();
            HeaderText = new ReactiveProperty<string>();
        }

        public ReactiveCollection<PropertyViewModel> Properties { get; }
        public ReactiveProperty<string> HeaderText { get; }

        public PropertiesPopupViewModel Setup(IReadOnlyDictionary<string, string> properties, string header)
        {
            Properties.AddRange(
                properties.Select(x => new PropertyViewModel(x.Key, x.Value)));
            
            HeaderText.SetValueNotify(header);
            
            return this;
        }
    }
}