using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
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