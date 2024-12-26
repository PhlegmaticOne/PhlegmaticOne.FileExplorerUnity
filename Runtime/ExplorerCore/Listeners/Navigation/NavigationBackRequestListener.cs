using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Listeners.Navigation
{
    internal sealed class NavigationBackRequestListener : IUpdateListener
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IExplorerStateProvider _explorerStateProvider;

        public NavigationBackRequestListener(
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel,
            IExplorerStateProvider explorerStateProvider)
        {
            _selectionViewModel = selectionViewModel;
            _navigationViewModel = navigationViewModel;
            _explorerStateProvider = explorerStateProvider;
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (!Input.GetKeyUp(KeyCode.Escape))
            {
                return;
            }

            if (_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.Clear();
                return;
            }
            
            if (!_navigationViewModel.NavigateBack())
            {
                _explorerStateProvider.Close();
            }
        }
    }
}