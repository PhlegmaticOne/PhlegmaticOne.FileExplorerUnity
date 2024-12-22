using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions.Services;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files
{
    internal sealed class FileViewModel : FileEntryViewModel
    {
        private readonly IFileEntryActionsProvider _actionsProvider;
        private readonly ExplorerFileIcon _fileIcon;
        
        public FileViewModel(
            string name, string path, string extension,
            IExplorerIconsProvider iconsProvider,
            IFileEntryActionsProvider actionsProvider,
            SelectionViewModel selectionViewModel,
            IFileOperations fileOperations,
            IFileExtensions fileExtensions) : 
            base(name, path, iconsProvider, selectionViewModel, fileOperations)
        {
            _actionsProvider = actionsProvider;
            Extension = new FileExtension(fileExtensions, extension);
            _fileIcon = new ExplorerFileIcon(this, iconsProvider);
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