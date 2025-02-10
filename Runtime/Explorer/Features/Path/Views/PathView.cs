using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Views
{
    internal sealed class PathView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private PathPartViewCollection _viewCollection;

        private PathViewModel _viewModel;

        [ViewInject]
        public void Construct(PathViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.PathParts.CollectionChanged += _viewCollection.UpdateView;
        }

        public void Unbind()
        {
            _viewModel.PathParts.CollectionChanged -= _viewCollection.UpdateView;
        }
    }
}