using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertyViewModel : ViewModel
    {
        public PropertyViewModel(string name, string value)
        {
            Name = new ReactiveProperty<string>(name);
            Value = new ReactiveProperty<string>(value);
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<string> Value { get; }
    }
}