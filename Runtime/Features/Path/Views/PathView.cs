﻿using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Views
{
    internal sealed class PathView : MonoBehaviour, IExplorerViewComponent
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