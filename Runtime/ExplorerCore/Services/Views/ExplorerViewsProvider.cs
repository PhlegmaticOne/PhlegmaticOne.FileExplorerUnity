﻿using System;
using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views
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
            foreach (var viewComponent in _viewComponents.AsSpan())
            {
                viewComponent.Unbind();
            }
        }
    }
}