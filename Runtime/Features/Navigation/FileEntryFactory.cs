using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class FileEntryFactory : IFileEntryFactory
    {
        private readonly IExplorerIconsProvider _iconsProvider;
        
        private NavigationViewModel _navigationViewModel;

        public FileEntryFactory(IExplorerIconsProvider iconsProvider)
        {
            _iconsProvider = iconsProvider;
        }

        public void SetupNavigation(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }
        
        public FileEntryViewModel CreateEntry(FileSystemInfo fileEntry)
        {
            if (File.Exists(fileEntry.FullName))
            {
                return new FileViewModel(
                    fileEntry.FullName, fileEntry.Name, fileEntry.Extension,
                    _iconsProvider);
            }

            return new DirectoryViewModel(fileEntry.FullName, fileEntry.Name, _iconsProvider, _navigationViewModel);
        }
    }
}