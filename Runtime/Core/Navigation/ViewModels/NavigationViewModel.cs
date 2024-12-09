using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.Navigation;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels
{
    internal sealed class NavigationViewModel
    {
        private readonly IExplorerNavigator _navigator;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly FileExplorerConfig _explorerConfig;

        public NavigationViewModel(
            IExplorerNavigator navigator, 
            IExplorerCancellationProvider cancellationProvider,
            FileEntryActionsViewModel actionsViewModel,
            FileExplorerConfig explorerConfig)
        {
            _navigator = navigator;
            _cancellationProvider = cancellationProvider;
            _actionsViewModel = actionsViewModel;
            _explorerConfig = explorerConfig;
            FileEntries = new ReactiveCollection<FileEntryViewModel>();
            Path = new ReactiveProperty<string>();
            IsLoading = new ReactiveProperty<bool>();
        }

        public ReactiveProperty<bool> IsLoading { get; }
        public ReactiveProperty<string> Path { get; }
        public ReactiveCollection<FileEntryViewModel> FileEntries { get; }

        public void Navigate(string path)
        {
            _cancellationProvider.Cancel();
            _actionsViewModel.Deactivate();
            ClearEntries();
            Path.SetValue(path);
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

        public bool IsEmpty()
        {
            return !IsLoading && FileEntries.Count == 0;
        }

        public void ClearEntries()
        {
            foreach (var fileEntry in FileEntries)
            {
                fileEntry.Dispose();
            }
            
            FileEntries.Clear();
        }

        private async Task LoadEntriesAsync()
        {
            IsLoading.SetValue(true);

            await foreach (var fileEntry in _navigator.Navigate(Path).WithCancellation(_cancellationProvider.Token))
            {
                FileEntries.Add(fileEntry);
                await Task.Yield();
            }
            
            IsLoading.SetValue(false);
        }

        private string GetParentPath()
        {
            return !CanMoveBack() ? Path : Directory.GetParent(Path)!.FullName.PathSlash();
        }
    }
}