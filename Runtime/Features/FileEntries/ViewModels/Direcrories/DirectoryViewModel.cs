using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories
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

        public override bool Exists()
        {
            return FileOperations.DirectoryExists(Path);
        }

        public override void OnClick()
        {
            if (SelectionViewModel.IsSelectionActive)
            {
                SelectionViewModel.UpdateSelection(this);
            }
            else
            {
                _navigationViewModel.Navigate(this);
            }
        }

        public override void Dispose()
        {
            Icon.SetIcon(null);
        }
    }
}