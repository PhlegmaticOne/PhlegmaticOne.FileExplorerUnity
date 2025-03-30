using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities;
using PhlegmaticOne.FileExplorer.Features.Searching.Services.Filters;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Listeners;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Entities
{
    internal sealed class SearchViewModel : ViewModel, ITabEntriesAddedHandler, IViewModelDisposable
    {
        private const int MinSearchLength = 2;
        
        private readonly TabViewModel _tabViewModel;
        private readonly HeaderInfoViewModel _headerInfoViewModel;
        private readonly IFileEntrySearchFilter _fileEntrySearchFilter;

        public SearchViewModel(
            TabViewModel tabViewModel, 
            HeaderInfoViewModel headerInfoViewModel,
            IFileEntrySearchFilter fileEntrySearchFilter)
        {
            _tabViewModel = tabViewModel;
            _headerInfoViewModel = headerInfoViewModel;
            _fileEntrySearchFilter = fileEntrySearchFilter;

            IsActive = new ReactiveProperty<bool>(true);
            SearchText = new ReactiveProperty<string>(string.Empty);
            IsSearching = new ReactiveProperty<bool>(false);
            FoundEntriesCount = new ReactiveProperty<int>(-1);
            ResetCommand = new CommandDelegateEmpty(Clear);
            SearchCommand = new CommandDelegate<string>(Search);
        }

        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<bool> IsSearching { get; }
        public ReactiveProperty<string> SearchText { get; }
        public ReactiveProperty<int> FoundEntriesCount { get; }
        public ICommand ResetCommand { get; }
        public ICommand SearchCommand { get; }

        public void Research()
        {
            Search(SearchText);
        }

        public void SetActive(bool isActive)
        {
            IsActive.SetValueNotify(isActive);
        }

        public void HandleEntriesAdded(IEnumerable<FileEntryViewModel> fileEntries)
        {
            if (!IsSearching && string.IsNullOrEmpty(SearchText))
            {
                return;
            }
            
            var foundEntriesCount = SearchEntries(SearchText, fileEntries);

            if (foundEntriesCount > 0)
            {
                var newFoundCount = FoundEntriesCount + foundEntriesCount;
                FoundEntriesCount.OverwriteForce(newFoundCount);
                UpdateFoundEntriesCountHeader();
            }
        }

        public void Clear()
        {
            SearchText.SetValueNotify(string.Empty);
            SetAllFileEntriesActive();
            IsSearching.SetValueNotify(false);
            FoundEntriesCount.SetValueWithoutNotify(-1);
            UpdateFoundEntriesCountHeader();
        }

        private void Search(string text)
        {
            var foundEntriesCount = SearchEntries(text, _tabViewModel.FileEntries);
            IsSearching.SetValueNotify(foundEntriesCount != -1);
            FoundEntriesCount.OverwriteForce(foundEntriesCount);
            UpdateFoundEntriesCountHeader();
        }

        private void UpdateFoundEntriesCountHeader()
        {
            var message = FoundEntriesCount == -1 ? string.Empty : $"Found entries: {FoundEntriesCount}";
            _headerInfoViewModel.SetInfoMessage(message);
        }

        private int SearchEntries(string text, IEnumerable<FileEntryViewModel> fileEntries)
        {
            if (text.Length >= MinSearchLength)
            {
                return FilterFileEntries(text, fileEntries);
            }

            SetAllFileEntriesActive();
            return -1;
        }

        private int FilterFileEntries(string text, IEnumerable<FileEntryViewModel> fileEntries)
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

        public void Dispose()
        {
            Clear();
        }
    }
}