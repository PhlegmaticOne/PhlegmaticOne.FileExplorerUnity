using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using PhlegmaticOne.FileExplorer.States;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.Listeners
{
    internal sealed class BackPressedListener : IUpdateListener
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IExplorerStateProvider _explorerStateProvider;

        public BackPressedListener(
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
            
            if(!_navigationViewModel.NavigateBack())
            {
                _explorerStateProvider.Close();
            }
        }
    }
}