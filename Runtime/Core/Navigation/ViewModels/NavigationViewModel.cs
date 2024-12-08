using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Navigation;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels
{
    internal sealed class NavigationViewModel
    {
        private readonly IExplorerNavigator _navigator;
        private readonly FileExplorerConfig _explorerConfig;

        public NavigationViewModel(IExplorerNavigator navigator, FileExplorerConfig explorerConfig)
        {
            _navigator = navigator;
            _explorerConfig = explorerConfig;
            FileEntries = new ObservableCollection<FileEntryViewModel>();
        }

        public event Action NavigationStarted;
        public event Action NavigationCompleted;
        
        public string Path { get; private set; }
        public string ParentPath { get; private set; }
        public ObservableCollection<FileEntryViewModel> FileEntries { get; }

        public bool CanMoveBack()
        {
            return !Path.Equals(_explorerConfig.RootPath);
        }

        public void Navigate(string path)
        {
            Path = path;
            UpdateParentPath(path);
            DisposeCurrentEntries();
            LoadEntriesAsync().Forget();
        }

        public void NavigateBack()
        {
            if (CanMoveBack())
            {
                Navigate(ParentPath);
            }
        }

        private async Task LoadEntriesAsync()
        {
            NavigationStarted?.Invoke();
            
            await foreach (var fileEntry in _navigator.Navigate(Path))
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

        private void UpdateParentPath(string path)
        {
            if (path.Equals(_explorerConfig.RootPath))
            {
                ParentPath = path;
            }
            else
            {
                ParentPath = Directory.GetParent(path)?.FullName.PathSlash() ?? string.Empty;
            }
        }
    }
}