using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels
{
    internal sealed class NavigationViewModel : ViewModel
    {
        private readonly IExplorerNavigator _navigator;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly TabViewModel _tabViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly PathViewModel _pathViewModel;
        private readonly INavigationProgressSetter _progressSetter;
        private readonly ExplorerConfig _config;

        public NavigationViewModel(
            IExplorerNavigator navigator, 
            IExplorerCancellationProvider cancellationProvider,
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel,
            SearchViewModel searchViewModel,
            PathViewModel pathViewModel,
            INavigationProgressSetter progressSetter,
            ExplorerConfig config)
        {
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
            _pathViewModel = pathViewModel;
            _progressSetter = progressSetter;
            _config = config;
            _navigator = navigator;
            _cancellationProvider = cancellationProvider;
            _selectionViewModel = selectionViewModel;
            IsLoading = new ReactiveProperty<bool>();
        }

        public ReactiveProperty<bool> IsLoading { get; }

        public void Navigate(string path)
        {
            _cancellationProvider.Cancel();
            _progressSetter.SetActive(false);
            _tabViewModel.Clear();
            _selectionViewModel.Clear();
            _searchViewModel.Clear();
            _pathViewModel.UpdatePathParts(path);
            LoadTabAsync(_pathViewModel.Path).ForgetUnawareCancellation();
        }

        public void Navigate(DirectoryViewModel directory)
        {
            if (!directory.Exists())
            {
                _tabViewModel.Remove(directory);
            }
            else
            {
                Navigate(directory.Path);
            }
        }

        public void NavigateRoot()
        {
            Navigate(_pathViewModel.GetRootPath());
        }

        public bool NavigateBack()
        {
            if (!CanMoveBack())
            {
                return false;
            }
            
            Navigate(_pathViewModel.GetParentPath());
            return true;
        }

        public bool CanMoveBack()
        {
            return !_pathViewModel.CurrentPathIsRoot();
        }

        private async Task LoadTabAsync(string path)
        {
            IsLoading.SetValueNotify(true);
            _progressSetter.SetActive(true);

            await LoadFileEntriesAsync(path);
            
            _progressSetter.Complete();
            _tabViewModel.UpdateIsEmpty();
            IsLoading.SetValueNotify(false);

            await Task.Delay(100, _cancellationProvider.Token);
            _progressSetter.SetActive(false);
        }

        private async Task LoadFileEntriesAsync(string path)
        {
            var batchCount = _config.View.AddFileEntriesBatchCount;
            var batch = new List<FileEntryViewModel>(batchCount);
            var token = _cancellationProvider.Token;
            
            await foreach (var fileEntry in _navigator.Navigate(path).WithCancellation(token))
            {
                batch.Add(fileEntry);

                if (batch.Count == batchCount)
                {
                    AddBatchToTab();
                }
                
                await Task.Yield();
            }

            if (batch.Count > 0)
            {
                AddBatchToTab();
                await Task.Yield();
            }

            return;

            void AddBatchToTab()
            {
                _tabViewModel.AddRange(batch);
                _progressSetter.AddDeltaProgress(batch.Count);
                batch.Clear();
            }
        }
    }
}