using PhlegmaticOne.FileExplorer.Features.Searching.Services;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Searching.ViewModels
{
    internal sealed class SearchViewModel : ViewModel
    {
        private const int MinSearchLength = 2;
        
        private readonly TabViewModel _tabViewModel;
        private readonly IFileEntryFinder _fileEntryFinder;

        public SearchViewModel(TabViewModel tabViewModel, IFileEntryFinder fileEntryFinder)
        {
            _tabViewModel = tabViewModel;
            _fileEntryFinder = fileEntryFinder;
            
            SearchText = new ReactiveProperty<string>(string.Empty);
            IsActive = new ReactiveProperty<bool>(false);
            FoundEntriesCount = new ReactiveProperty<int>(-1);
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<string> SearchText { get; }
        public ReactiveProperty<int> FoundEntriesCount { get; }

        public void Research()
        {
            Search(SearchText);
        }
        
        public void Search(string text)
        {
            SearchText.SetValueWithoutNotify(text);
            var foundEntriesCount = SearchEntries(text);
            FoundEntriesCount.OverwriteForce(foundEntriesCount);
            IsActive.SetValueNotify(foundEntriesCount != -1);
        }

        public void Clear()
        {
            SearchText.SetValueNotify(string.Empty);
            SetAllFileEntriesActive();
            FoundEntriesCount.SetValueWithoutNotify(-1);
            IsActive.SetValueNotify(false);
        }

        private int SearchEntries(string text)
        {
            if (text.Length >= MinSearchLength)
            {
                return SearchFileEntries(text);
            }

            SetAllFileEntriesActive();
            return -1;
        }

        private int SearchFileEntries(string text)
        {
            var count = 0;
            
            foreach (var fileEntry in _tabViewModel.FileEntries)
            {
                var isFound = _fileEntryFinder.Find(fileEntry, text);
                fileEntry.IsActive.SetValueNotify(isFound);
                count += isFound ? 1 : 0;
            }

            return count;
        }

        private void SetAllFileEntriesActive()
        {
            foreach (var fileEntry in _tabViewModel.FileEntries)
            {
                fileEntry.IsActive.SetValueNotify(true);
            }
        }
    }
}