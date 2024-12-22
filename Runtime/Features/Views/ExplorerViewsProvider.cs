using System;

namespace PhlegmaticOne.FileExplorer.Features.Views
{
    internal sealed class ExplorerViewsProvider : IExplorerViewsProvider
    {
        private readonly IExplorerViewComponent[] _viewComponents;

        public ExplorerViewsProvider(IExplorerViewComponent[] viewComponents)
        {
            _viewComponents = viewComponents;
        }
        
        public void Bind()
        {
            foreach (var viewComponent in _viewComponents.AsSpan())
            {
                viewComponent.Bind();
            }
        }

        public void Unbind()
        {
            foreach (var viewComponent in _viewComponents)
            {
                viewComponent.Unbind();
            }
        }
    }
}