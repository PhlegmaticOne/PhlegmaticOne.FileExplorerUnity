using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common
{
    internal sealed class FileEntryActionProperties : FileEntryAction
    {
        private readonly IFileEntryPropertiesViewProvider _propertiesViewProvider;

        public FileEntryActionProperties(
            IFileEntryPropertiesViewProvider propertiesViewProvider,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _propertiesViewProvider = propertiesViewProvider;
        }

        public override string Description => "Properties";
        
        public override FileEntryActionColor Color => FileEntryActionColor.Auto;
        
        protected override async Task<bool> ExecuteAction()
        {
            await _propertiesViewProvider.ViewFileProperties(FileEntry);
            return true;
        }
    }
}