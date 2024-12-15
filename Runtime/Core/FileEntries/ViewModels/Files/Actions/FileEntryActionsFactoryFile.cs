using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files
{
    internal sealed class FileEntryActionsFactoryFile : FileEntryActionsFactory<FileViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly IFileEntryRenameDataProvider _renameDataProvider;
        private readonly IFileEntryPropertiesViewProvider _propertiesViewProvider;
        private readonly IFileViewProvider _fileViewProvider;
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionsFactoryFile(
            FileEntryActionsViewModel actionsViewModel,
            IFileEntryRenameDataProvider renameDataProvider,
            IFileEntryPropertiesViewProvider propertiesViewProvider,
            IFileViewProvider fileViewProvider,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _renameDataProvider = renameDataProvider;
            _propertiesViewProvider = propertiesViewProvider;
            _fileViewProvider = fileViewProvider;
            _tabViewModel = tabViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(FileViewModel fileEntry)
        {
            if (fileEntry.Extension.IsViewable(out var viewType))
            {
                yield return ViewFile(fileEntry, viewType, Color.green);
            }

            if (!fileEntry.Extension.HasValue())
            {
                yield return ViewFile(fileEntry, FileViewType.Image, Color.yellow);
                yield return ViewFile(fileEntry, FileViewType.Text, Color.yellow);
            }

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

        private FileEntryActionViewFile ViewFile(FileViewModel viewModel, FileViewType viewType, Color color)
        {
            return new FileEntryActionViewFile(viewModel, viewType, color, _fileViewProvider, _actionsViewModel);
        }
    }
}