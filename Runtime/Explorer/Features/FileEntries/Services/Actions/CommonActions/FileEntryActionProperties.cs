using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Popups.Properties;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal sealed class FileEntryActionProperties : FileEntryAction
    {
        private readonly IPropertiesPopupProvider _propertiesPopupProvider;

        public FileEntryActionProperties(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler,
            IPropertiesPopupProvider propertiesPopupProvider) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _propertiesPopupProvider = propertiesPopupProvider;
        }

        public override string Description => "Properties";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _propertiesPopupProvider.ViewFileProperties(fileEntry);
        }
    }
}