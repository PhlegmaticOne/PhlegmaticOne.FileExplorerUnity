using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories
{
    internal sealed class FileEntryActionsFactoryDirectory : FileEntryActionsFactory<DirectoryViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly IFileEntryRenameDataProvider _renameDataProvider;
        private readonly IFileEntryPropertiesViewProvider _propertiesViewProvider;
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionsFactoryDirectory(
            FileEntryActionsViewModel actionsViewModel,
            IFileEntryRenameDataProvider renameDataProvider,
            IFileEntryPropertiesViewProvider propertiesViewProvider,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _renameDataProvider = renameDataProvider;
            _propertiesViewProvider = propertiesViewProvider;
            _tabViewModel = tabViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(DirectoryViewModel fileEntry)
        {
#if UNITY_EDITOR
            yield return new FileEntryActionOpenExplorer(fileEntry, _actionsViewModel);
#endif
            yield return Rename(fileEntry);
            yield return Properties(fileEntry);
            yield return Delete(fileEntry);
        }
        
        private FileEntryActionDelete Delete(FileEntryViewModel viewModel)
        {
            return new FileEntryActionDelete(viewModel, _tabViewModel, _actionsViewModel);
        }

        private FileEntryActionProperties Properties(FileEntryViewModel viewModel)
        {
            return new FileEntryActionProperties(viewModel, _propertiesViewProvider, _actionsViewModel);
        }

        private FileEntryActionRename Rename(FileEntryViewModel viewModel)
        {
            return new FileEntryActionRename(viewModel, _renameDataProvider, _actionsViewModel);
        }
    }
}