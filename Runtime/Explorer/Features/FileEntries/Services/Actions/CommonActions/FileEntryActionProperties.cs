using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionProperties : FileEntryAction
    {
        private readonly IFilePropertiesViewProvider _propertiesViewProvider;

        public FileEntryActionProperties(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler,
            IFilePropertiesViewProvider propertiesViewProvider) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _propertiesViewProvider = propertiesViewProvider;
        }

        public override string Description => "Properties";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _propertiesViewProvider.ViewFileProperties(fileEntry);
        }
    }
}