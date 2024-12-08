using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.Views
{
    internal sealed class FileExplorerView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private NavigationView _navigationView;

        public void Bind(NavigationViewModel viewModel)
        {
            _canvas.worldCamera = Camera.main;
            _navigationView.Bind(viewModel);
        }
    }
}