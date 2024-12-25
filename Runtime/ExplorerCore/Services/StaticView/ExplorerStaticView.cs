using PhlegmaticOne.FileExplorer.Configuration;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Services.StaticView
{
    internal sealed class ExplorerStaticView : IExplorerStaticView
    {
        private readonly Canvas _canvas;
        private readonly ExplorerConfig _explorerConfig;

        public ExplorerStaticView(Canvas canvas, ExplorerConfig explorerConfig)
        {
            _canvas = canvas;
            _explorerConfig = explorerConfig;
        }
        
        public void Setup()
        {
            SetupCanvas();
            SetupStaticTextFont();
        }
        
        private void SetupCanvas()
        {
            _canvas.sortingLayerName = _explorerConfig.View.SortingLayerName;
            _canvas.sortingOrder = _explorerConfig.View.SortingOrder;
            _canvas.worldCamera = Camera.main;
        }

        private void SetupStaticTextFont()
        {
            foreach (var textMeshPro in Object.FindObjectsByType<TextMeshProUGUI>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                textMeshPro.font = _explorerConfig.View.FontAsset;
            }

            foreach (var inputField in Object.FindObjectsByType<TMP_InputField>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                inputField.fontAsset = _explorerConfig.View.FontAsset;
            }
        }
    }
}