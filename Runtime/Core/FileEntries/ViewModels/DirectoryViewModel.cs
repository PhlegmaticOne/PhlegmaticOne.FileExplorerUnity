using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Positioning;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal sealed class DirectoryViewModel : FileEntryViewModel
    {
        private const string DirectoryExtension = "directory";
        
        private readonly NavigationViewModel _navigationViewModel;

        private Sprite _directoryIcon;
        
        public DirectoryViewModel(
            string path, string name, FileEntryPosition position,
            IExplorerIconsProvider iconsProvider, 
            FileEntryActionsProvider actionsProvider,
            NavigationViewModel navigationViewModel) : 
            base(path, name, position, iconsProvider, actionsProvider)
        {
            _navigationViewModel = navigationViewModel;
        }

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            _directoryIcon = await IconsProvider.GetIconAsync(DirectoryExtension, cancellationToken);
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