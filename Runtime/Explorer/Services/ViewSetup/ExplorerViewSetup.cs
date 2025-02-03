using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.StaticView
{
    internal sealed class ExplorerViewSetup : IExplorerViewSetup
    {
        private readonly ExplorerConfig _explorerConfig;
        private readonly Camera _viewCamera;
        private readonly ExplorerSceneObjects _sceneObjects;

        public ExplorerViewSetup(
            ExplorerConfig explorerConfig, 
            Camera viewCamera, 
            ExplorerSceneObjects sceneObjects)
        {
            _viewCamera = viewCamera;
            _sceneObjects = sceneObjects;
            _explorerConfig = explorerConfig;
        }
        
        public void Setup()
        {
            SetupCanvas();
            SetupFont();
        }
        
        private void SetupCanvas()
        {
            var canvas = _sceneObjects.Canvas;
            canvas.worldCamera = _viewCamera;
            canvas.sortingLayerName = _explorerConfig.View.SortingLayerName;
            canvas.sortingOrder = _explorerConfig.View.SortingOrder;
        }

        private void SetupFont()
        {
            var rootBehaviour = _sceneObjects.RootBehaviour;
            
            foreach (var textComponent in rootBehaviour.TextsInChild())
            {
                textComponent.SetFont(_explorerConfig.View.FontAsset);
            }
        }
    }
}