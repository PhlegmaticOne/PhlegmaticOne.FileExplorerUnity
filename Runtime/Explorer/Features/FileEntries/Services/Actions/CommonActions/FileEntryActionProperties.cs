using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionProperties : FileEntryAction
    {
        private readonly IFilePropertiesViewProvider _propertiesViewProvider;

        public FileEntryActionProperties(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IFileEntryActionExecuteHandler executeHandler,
            IFilePropertiesViewProvider propertiesViewProvider) : 
            base(fileEntry, actionsViewModel, executeHandler)
        {
            _propertiesViewProvider = propertiesViewProvider;
        }

        public override string Description => "Properties";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task<bool> ExecuteAction(FileEntryViewModel fileEntry)
        {
            await _propertiesViewProvider.ViewFileProperties(fileEntry);
            return true;
        }
    }
}