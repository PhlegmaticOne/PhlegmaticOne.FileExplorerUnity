﻿using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

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

        public NavigationViewModel(
            IExplorerNavigator navigator, 
            IExplorerCancellationProvider cancellationProvider,
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel,
            SearchViewModel searchViewModel,
            PathViewModel pathViewModel)
        {
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
            _pathViewModel = pathViewModel;
            _navigator = navigator;
            _cancellationProvider = cancellationProvider;
            _selectionViewModel = selectionViewModel;
            IsLoading = new ReactiveProperty<bool>();
        }

        public ReactiveProperty<bool> IsLoading { get; }

        public void Navigate(string path)
        {
            _cancellationProvider.Cancel();
            _tabViewModel.Clear();
            _selectionViewModel.Clear();
            _searchViewModel.Clear();
            _pathViewModel.UpdatePathParts(path.PathSlash());
            LoadEntriesAsync().ForgetUnawareCancellation();
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

        private async Task LoadEntriesAsync()
        {
            IsLoading.SetValueNotify(true);

            await foreach (var fileEntry in _navigator.Navigate(_pathViewModel.Path)
                               .WithCancellation(_cancellationProvider.Token))
            {
                _tabViewModel.Add(fileEntry);
                await Task.Yield();
            }

            _tabViewModel.UpdateIsEmpty();
            IsLoading.SetValueNotify(false);
        }
    }
}