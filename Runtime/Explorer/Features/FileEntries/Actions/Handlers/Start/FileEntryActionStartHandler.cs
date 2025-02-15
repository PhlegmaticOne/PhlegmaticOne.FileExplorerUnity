using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal sealed class FileEntryActionStartHandler : IFileEntryActionStartHandler
    {
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionStartHandler(TabViewModel tabViewModel)
        {
            _tabViewModel = tabViewModel;
        }

        public bool ProcessCanStartAction(FileEntryViewModel fileEntry)
        {
            if (fileEntry.Exists())
            {
                return true;
            }
            
            _tabViewModel.Remove(fileEntry);
            return false;
        }
    }
}