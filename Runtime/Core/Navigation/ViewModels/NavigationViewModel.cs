using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.Navigation;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels
{
    internal sealed class NavigationViewModel
    {
        private readonly IExplorerNavigator _navigator;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly FileExplorerConfig _explorerConfig;

        public NavigationViewModel(
            IExplorerNavigator navigator, 
            IExplorerCancellationProvider cancellationProvider,
            FileExplorerConfig explorerConfig)
        {
            _navigator = navigator;
            _cancellationProvider = cancellationProvider;
            _explorerConfig = explorerConfig;
            FileEntries = new ObservableCollection<FileEntryViewModel>();
        }

        public event Action NavigationStarted;
        public event Action NavigationCompleted;
        
        public string Path { get; private set; }
        public ObservableCollection<FileEntryViewModel> FileEntries { get; }

        public bool CanMoveBack()
        {
            return !Path.Equals(_explorerConfig.RootPath);
        }

        public void Navigate(string path)
        {
            Path = path;
            _cancellationProvider.Cancel();
            DisposeCurrentEntries();
            LoadEntriesAsync().ForgetUnawareCancellation();
        }

        public void NavigateBack()
        {
            if (CanMoveBack())
            {
                Navigate(GetParentPath());
            }
        }

        private async Task LoadEntriesAsync()
        {
            NavigationStarted?.Invoke();

            await foreach (var fileEntry in _navigator.Navigate(Path).WithCancellation(_cancellationProvider.Token))
            {
                FileEntries.Add(fileEntry);
                await Task.Yield();
            }
            
            NavigationCompleted?.Invoke();
        }

        private void DisposeCurrentEntries()
        {
            foreach (var fileEntry in FileEntries)
            {
                fileEntry.Dispose();
            }
            
            FileEntries.Clear();
        }

        private string GetParentPath()
        {
            return !CanMoveBack() ? Path : Directory.GetParent(Path)!.FullName.PathSlash();
        }
    }
}