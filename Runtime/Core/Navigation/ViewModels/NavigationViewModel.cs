using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.Navigation;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels
{
    internal sealed class NavigationViewModel
    {
        private readonly IExplorerNavigator _navigator;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly FileExplorerConfig _explorerConfig;
        private readonly TabViewModel _tabViewModel;
        private readonly ScreenMessagesViewModel _screenMessagesViewModel;
        private readonly SearchViewModel _searchViewModel;

        public NavigationViewModel(
            IExplorerNavigator navigator, 
            IExplorerCancellationProvider cancellationProvider,
            SelectionViewModel selectionViewModel,
            FileExplorerConfig explorerConfig,
            TabViewModel tabViewModel,
            ScreenMessagesViewModel screenMessagesViewModel,
            SearchViewModel searchViewModel)
        {
            _tabViewModel = tabViewModel;
            _screenMessagesViewModel = screenMessagesViewModel;
            _searchViewModel = searchViewModel;
            _navigator = navigator;
            _cancellationProvider = cancellationProvider;
            _selectionViewModel = selectionViewModel;
            _explorerConfig = explorerConfig;
            Path = new ReactiveProperty<string>();
            IsLoading = new ReactiveProperty<bool>();
        }

        public ReactiveProperty<bool> IsLoading { get; }
        public ReactiveProperty<string> Path { get; }

        public void Navigate(string path)
        {
            _cancellationProvider.Cancel();
            _tabViewModel.Clear();
            _selectionViewModel.ClearSelection();
            _searchViewModel.Reset();
            Path.SetValueNotify(path);
            LoadEntriesAsync().ForgetUnawareCancellation();
        }

        public void NavigateRoot()
        {
            Navigate(_explorerConfig.RootPath);
        }

        public bool NavigateBack()
        {
            if (!CanMoveBack())
            {
                return false;
            }
            
            Navigate(GetParentPath());
            return true;
        }

        public bool CanMoveBack()
        {
            return !Path.Value.Equals(_explorerConfig.RootPath);
        }

        public void SetLoadingMessage(string loadingMessage)
        {
            _screenMessagesViewModel.HeaderMessage.SetValueNotify(
                new ScreenMessageData(loadingMessage, Color.green));
        }

        private async Task LoadEntriesAsync()
        {
            SetLoadingState(true);

            await foreach (var fileEntry in _navigator.Navigate(Path).WithCancellation(_cancellationProvider.Token))
            {
                _tabViewModel.Add(fileEntry);
                await Task.Yield();
            }

            _tabViewModel.UpdateIsEmpty();
            SetLoadingState(false);
        }

        private void SetLoadingState(bool isLoading)
        {
            _screenMessagesViewModel.IsHeaderMessageActive.SetValueNotify(isLoading);
            IsLoading.SetValueNotify(isLoading);
        }

        private string GetParentPath()
        {
            return !CanMoveBack() ? Path : Directory.GetParent(Path)!.FullName.PathSlash();
        }
    }
}