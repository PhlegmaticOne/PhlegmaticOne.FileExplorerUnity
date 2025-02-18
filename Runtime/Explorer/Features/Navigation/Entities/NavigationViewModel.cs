using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services.EntriesGenerationPolicies;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services.Progress;
using PhlegmaticOne.FileExplorer.Features.Path.Entities.Path;
using PhlegmaticOne.FileExplorer.Features.Searching.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Entities
{
    internal sealed class NavigationViewModel : ViewModel
    {
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IFileEntriesGenerationPolicy _entriesGenerationPolicy;
        private readonly TabViewModel _tabViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly PathViewModel _pathViewModel;
        private readonly INavigationProgressSetter _progressSetter;

        public NavigationViewModel(
            IFileEntriesGenerationPolicy entriesGenerationPolicy, 
            IExplorerCancellationProvider cancellationProvider,
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel,
            SearchViewModel searchViewModel,
            PathViewModel pathViewModel,
            INavigationProgressSetter progressSetter)
        {
            _entriesGenerationPolicy = entriesGenerationPolicy;
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
            _pathViewModel = pathViewModel;
            _progressSetter = progressSetter;
            _cancellationProvider = cancellationProvider;
            _selectionViewModel = selectionViewModel;
            NavigateBackCommand = new CommandDelegateEmpty(() => NavigateBack(), CanMoveBack);
        }
        
        public ICommand NavigateBackCommand { get; }

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

        private bool CanMoveBack()
        {
            return !_pathViewModel.CurrentPathIsRoot();
        }

        private async Task LoadTabAsync(string path)
        {
            var token = _cancellationProvider.Token;
            NavigateBackCommand.RaiseCanExecuteChanged();
            _progressSetter.SetActive(true);

            await _entriesGenerationPolicy.GenerateFileEntriesAtPath(path, token, entries =>
            {
                _tabViewModel.AddRange(entries);
                _progressSetter.AddDeltaProgress(entries.Count);
            });

            if (!token.IsCancellationRequested)
            {
                _progressSetter.Complete();
                _tabViewModel.UpdateIsEmpty();
                NavigateBackCommand.RaiseCanExecuteChanged();
                await Task.Delay(100, token);
                _progressSetter.SetActive(false);
            }
        }
    }
}