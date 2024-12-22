using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.Services;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Directories;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories
{
    internal sealed class DirectoryViewModel : FileEntryViewModel
    {
        private const string DirectoryExtension = "directory";
        
        private readonly NavigationViewModel _navigationViewModel;

        public DirectoryViewModel(
            string name, string path,
            IExplorerIconsProvider iconsProvider, 
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel,
            IFileOperations fileOperations) : 
            base(name, path, iconsProvider, selectionViewModel, fileOperations)
        {
            _navigationViewModel = navigationViewModel;
        }

        public override FileEntryType EntryType => FileEntryType.Directory;

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            var directoryIcon = await IconsProvider.GetIconAsync(DirectoryExtension, cancellationToken);
            Icon.SetIcon(directoryIcon);
        }

        public override FileEntryProperties GetProperties()
        {
            return new DirectoryProperties(Path);
        }

        public override void Rename(string newName)
        {
            Path = FileOperations.RenameDirectory(Path, newName);
            Name.SetValueNotify(newName);
        }

        public override void Delete()
        {
            FileOperations.DeleteDirectory(Path);
        }
        
        public override void OnClick()
        {
            if (SelectionViewModel.IsSelectionActive)
            {
                SelectionViewModel.UpdateSelection(this);
            }
            else
            {
                _navigationViewModel.Navigate(Path);
            }
        }

        public override void Dispose()
        {
            Icon.SetIcon(null);
        }
    }
}