using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories
{
    internal sealed class DirectoryViewModel : FileEntryViewModel
    {
        private const string DirectoryExtension = "directory";
        
        private readonly NavigationViewModel _navigationViewModel;

        private Sprite _directoryIcon;
        
        public DirectoryViewModel(
            string path, string name,
            IExplorerIconsProvider iconsProvider, 
            FileEntryActionsProvider actionsProvider,
            NavigationViewModel navigationViewModel,
            IFileOperations fileOperations) : 
            base(path, name, iconsProvider, actionsProvider, fileOperations)
        {
            _navigationViewModel = navigationViewModel;
        }

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            _directoryIcon = await IconsProvider.GetIconAsync(DirectoryExtension, cancellationToken);
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

        public override ExplorerIconData GetIcon()
        {
            return new ExplorerIconData(_directoryIcon);
        }

        public override void OnClick()
        {
            _navigationViewModel.Navigate(Path);
        }

        public override void Dispose()
        {
            _directoryIcon = null;
        }
    }
}