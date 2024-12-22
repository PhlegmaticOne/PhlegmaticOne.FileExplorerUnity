using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal sealed class ExplorerViewModelDisposer : IExplorerViewModelDisposer
    {
        private readonly ActionsViewModel _actionsViewModel;
        private readonly TabViewModel _tabViewModel;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly PathViewModel _pathViewModel;

        public ExplorerViewModelDisposer(
            ActionsViewModel actionsViewModel,
            TabViewModel tabViewModel,
            SelectionViewModel selectionViewModel,
            SearchViewModel searchViewModel,
            PathViewModel pathViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _tabViewModel = tabViewModel;
            _selectionViewModel = selectionViewModel;
            _searchViewModel = searchViewModel;
            _pathViewModel = pathViewModel;
        }
        
        public void DisposeViewModels()
        {
            _actionsViewModel.Deactivate();
            _tabViewModel.Clear();
            _selectionViewModel.Clear();
            _searchViewModel.Clear();
            _pathViewModel.Clear();
        }
    }
}