using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Entities.Path
{
    internal sealed class PathView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentCollectionPathParts _pathParts;

        private PathViewModel _viewModel;

        [ViewInject]
        public void Construct(PathViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _pathParts.Bind(_viewModel.PathParts);
        }

        public void Unbind()
        {
            _pathParts.Release();
        }
    }
}