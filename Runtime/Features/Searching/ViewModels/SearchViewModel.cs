using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.Services;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Searching.ViewModels
{
    internal sealed class SearchViewModel : ViewModel
    {
        private const int MinSearchLength = 2;
        
        private readonly TabViewModel _tabViewModel;
        private readonly IFileEntrySearchFilter _fileEntrySearchFilter;

        public SearchViewModel(TabViewModel tabViewModel, IFileEntrySearchFilter fileEntrySearchFilter)
        {
            _tabViewModel = tabViewModel;
            _fileEntrySearchFilter = fileEntrySearchFilter;
            _tabViewModel.FileEntries.CollectionChanged += DynamicHandleFileEntriesSearchFilter;
            
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
            var foundEntriesCount = SearchEntries(text, _tabViewModel.FileEntries);
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
        
        private void DynamicHandleFileEntriesSearchFilter(
            ReactiveCollectionChangedEventArgs<FileEntryViewModel> eventArgs)
        {
            if (eventArgs.Action != ReactiveCollectionChangedAction.Add ||
                (!IsActive && string.IsNullOrEmpty(SearchText)))
            {
                return;
            }
            
            var foundEntriesCount = SearchEntries(SearchText, eventArgs.AffectedItems);

            if (foundEntriesCount > 0)
            {
                var newFoundCount = FoundEntriesCount + foundEntriesCount;
                FoundEntriesCount.OverwriteForce(newFoundCount);
            }
        }

        private int SearchEntries(string text, IEnumerable<FileEntryViewModel> fileEntries)
        {
            if (text.Length >= MinSearchLength)
            {
                return SearchFitFileEntries(text, fileEntries);
            }

            SetAllFileEntriesActive();
            return -1;
        }

        private int SearchFitFileEntries(string text, IEnumerable<FileEntryViewModel> fileEntries)
        {
            var count = 0;
            
            foreach (var fileEntry in fileEntries)
            {
                var isFit = _fileEntrySearchFilter.IsFit(fileEntry, text);
                fileEntry.IsActive.SetValueNotify(isFit);
                count += isFit ? 1 : 0;
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