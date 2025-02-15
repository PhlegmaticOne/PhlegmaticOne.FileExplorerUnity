using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Popups.Properties;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal sealed class FileEntryActionProperties : IFileEntryAction
    {
        private readonly IPropertiesPopupProvider _propertiesPopupProvider;

        public FileEntryActionProperties(IPropertiesPopupProvider propertiesPopupProvider)
        {
            _propertiesPopupProvider = propertiesPopupProvider;
        }

        public Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _propertiesPopupProvider.ViewFileProperties(fileEntry);
        }
    }
}