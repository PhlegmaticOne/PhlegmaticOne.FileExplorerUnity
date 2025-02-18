using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
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

        public Task Execute(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _propertiesPopupProvider.ViewFileProperties(fileEntry);
        }
    }
}