using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using PhlegmaticOne.FileExplorer.States;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class NavigationBackRequestListener : IUpdateListener
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IExplorerStates _explorerStates;

        public NavigationBackRequestListener(
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel,
            IExplorerStates explorerStates)
        {
            _selectionViewModel = selectionViewModel;
            _navigationViewModel = navigationViewModel;
            _explorerStates = explorerStates;
        }
        
        public void OnUpdate()
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
                _explorerStates.Close();
            }
        }
    }
}