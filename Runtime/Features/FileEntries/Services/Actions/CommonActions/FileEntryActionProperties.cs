using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionProperties : FileEntryAction
    {
        private readonly IFilePropertiesViewProvider _propertiesViewProvider;

        public FileEntryActionProperties(
            IFilePropertiesViewProvider propertiesViewProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _propertiesViewProvider = propertiesViewProvider;
        }

        public override string Description => "Properties";
        
        public override ExplorerActionColor Color => ExplorerActionColor.Auto;
        
        protected override async Task<bool> ExecuteAction()
        {
            await _propertiesViewProvider.ViewFileProperties(FileEntry);
            return true;
        }
    }
}