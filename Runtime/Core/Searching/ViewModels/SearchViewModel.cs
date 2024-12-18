﻿using PhlegmaticOne.FileExplorer.Core.Searching.Services;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Searching.ViewModels
{
    internal sealed class SearchViewModel
    {
        private const int MinSearchLength = 1;
        
        private readonly TabViewModel _tabViewModel;
        private readonly IFileEntryFinder _fileEntryFinder;

        public SearchViewModel(TabViewModel tabViewModel, IFileEntryFinder fileEntryFinder)
        {
            _tabViewModel = tabViewModel;
            _fileEntryFinder = fileEntryFinder;
            
            SearchText = new ReactiveProperty<string>(string.Empty);
            IsActive = new ReactiveProperty<bool>(false);
            FoundEntriesCount = -1;
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<string> SearchText { get; }
        public int FoundEntriesCount { get; private set; }

        public void Research()
        {
            Search(SearchText);
        }
        
        public void Search(string text)
        {
            SearchText.SetValueWithoutNotify(text);
            FoundEntriesCount = SearchEntries(text);
            IsActive.SetValueNotify(FoundEntriesCount != -1);
        }

        public void Reset()
        {
            SearchText.SetValueNotify(string.Empty);
            SetAllFileEntriesActive();
            FoundEntriesCount = -1;
            IsActive.SmartSetValueNotify(false);
        }

        private int SearchEntries(string text)
        {
            if (text.Length >= MinSearchLength)
            {
                return SearchFileEntries();
            }

            SetAllFileEntriesActive();
            return -1;
        }

        private int SearchFileEntries()
        {
            var searchText = SearchText.Value;
            var count = 0;
            
            foreach (var fileEntry in _tabViewModel.FileEntries)
            {
                var isFound = _fileEntryFinder.Find(fileEntry, searchText);
                fileEntry.IsActive.SmartSetValueNotify(isFound);
                count += isFound ? 1 : 0;
            }

            return count;
        }

        private void SetAllFileEntriesActive()
        {
            foreach (var fileEntry in _tabViewModel.FileEntries)
            {
                if (!fileEntry.IsActive)
                {
                    fileEntry.IsActive.SetValueNotify(true);
                }
            }
        }
    }
}