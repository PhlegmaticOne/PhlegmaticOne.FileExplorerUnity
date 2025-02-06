using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertyViewModel : ViewModel
    {
        public PropertyViewModel(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}