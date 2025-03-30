using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using PhlegmaticOne.FileExplorer.Lifecycle.Close;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Listeners
{
    internal sealed class NavigationBackRequestListener : IUpdateListener
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IExplorerCloseCommand _closeCommand;

        public NavigationBackRequestListener(
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel,
            IExplorerCloseCommand closeCommand)
        {
            _selectionViewModel = selectionViewModel;
            _navigationViewModel = navigationViewModel;
            _closeCommand = closeCommand;
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
                _closeCommand.Close();
            }
        }
    }
}