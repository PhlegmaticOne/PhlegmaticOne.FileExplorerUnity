using System;

namespace PhlegmaticOne.FileExplorer.Services.StaticViews
{
    internal sealed class ExplorerStaticViewComponentsProvider : IExplorerStaticViewComponentsProvider
    {
        private readonly IExplorerStaticViewComponent[] _viewComponents;

        public ExplorerStaticViewComponentsProvider(IExplorerStaticViewComponent[] viewComponents)
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
            foreach (var viewComponent in _viewComponents.AsSpan())
            {
                viewComponent.Unbind();
            }
        }
    }
}