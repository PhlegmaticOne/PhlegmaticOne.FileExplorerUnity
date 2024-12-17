using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Files;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files
{
    internal sealed class FileViewModel : FileEntryViewModel
    {
        private readonly FileEntryActionsProvider<FileEntryActionsFactoryFile> _actionsProvider;
        private readonly ExplorerFileIcon _fileIcon;
        
        public FileViewModel(
            IExplorerIconsProvider iconsProvider,
            FileEntryActionsProvider<FileEntryActionsFactoryFile> actionsProvider,
            SelectionViewModel selectionViewModel,
            IFileOperations fileOperations,
            IFileExtensions fileExtensions) : 
            base(iconsProvider, selectionViewModel, fileOperations)
        {
            _actionsProvider = actionsProvider;
            Extension = new FileExtension(fileExtensions);
            _fileIcon = new ExplorerFileIcon(this, iconsProvider);
        }

        public FileViewModel Construct(string name, string path, string extension)
        {
            Extension.SetExtension(extension);
            base.Construct(name, path);
            return this;
        }

        public FileExtension Extension { get; }

        public override FileEntryType EntryType => FileEntryType.File;

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await _fileIcon.EnsureLoadedAsync(cancellationToken);
            Icon.SetIcon(_fileIcon.GetIcon());
        }

        public override FileEntryProperties GetProperties()
        {
            return new FileProperties(Path);
        }

        public override void Rename(string newName)
        {
            Path = FileOperations.RenameFile(Path, newName);
            Name.SetValueNotify(newName + Extension);
        }

        public override void Delete()
        {
            FileOperations.DeleteFile(Path);
        }
        
        public override void OnClick()
        {
            if (SelectionViewModel.IsSelectionActive)
            {
                SelectionViewModel.UpdateSelection(this);
            }
            else
            {
                _actionsProvider.ShowActions(this);
            }
        }

        public override void Dispose()
        {
            _fileIcon.Dispose();
        }
    }
}