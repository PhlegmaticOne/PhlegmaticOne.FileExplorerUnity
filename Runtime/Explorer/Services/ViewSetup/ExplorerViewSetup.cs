using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.StaticView
{
    internal sealed class ExplorerViewSetup : IExplorerViewSetup
    {
        private readonly ExplorerConfig _explorerConfig;
        private readonly Camera _viewCamera;
        private readonly Canvas _canvas;

        public ExplorerViewSetup(ExplorerConfig explorerConfig, Camera viewCamera, Canvas canvas)
        {
            _viewCamera = viewCamera;
            _canvas = canvas;
            _explorerConfig = explorerConfig;
        }
        
        public void Setup()
        {
            SetupCanvas();
            SetupFont();
        }
        
        private void SetupCanvas()
        {
            _canvas.worldCamera = _viewCamera;
            _canvas.sortingLayerName = _explorerConfig.View.SortingLayerName;
            _canvas.sortingOrder = _explorerConfig.View.SortingOrder;
        }

        private void SetupFont()
        {
            foreach (var textComponent in FindTexts.Find())
            {
                textComponent.SetFont(_explorerConfig.View.FontAsset);
            }
        }
    }
}