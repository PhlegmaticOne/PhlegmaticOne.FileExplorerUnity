using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Directories;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories
{
    internal sealed class DirectoryViewModel : FileEntryViewModel
    {
        private const string DirectoryExtension = "directory";
        
        private readonly NavigationViewModel _navigationViewModel;

        public DirectoryViewModel(
            IExplorerIconsProvider iconsProvider, 
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel,
            IFileOperations fileOperations) : 
            base(iconsProvider, selectionViewModel, fileOperations)
        {
            _navigationViewModel = navigationViewModel;
        }

        public override FileEntryType EntryType => FileEntryType.Directory;

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            var directoryIcon = await IconsProvider.GetIconAsync(DirectoryExtension, cancellationToken);
            Icon.SetIcon(directoryIcon);
        }

        public override Dictionary<string, string> GetProperties()
        {
            var properties = new DirectoryProperties(Path);
            var baseProperties = properties.GetBaseProperties();
            baseProperties.Add("Size", properties.Size.BuildUnitView());
            baseProperties.Add("Entries", properties.BuildEntriesCounterView());
            return baseProperties;
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