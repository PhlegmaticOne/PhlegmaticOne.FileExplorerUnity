using PhlegmaticOne.FileExplorer.Configuration;
using TMPro;
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
            SetFontToTexts();
            SetFontToInputs();
        }
        
        private void SetupCanvas()
        {
            _canvas.worldCamera = _viewCamera;
            _canvas.sortingLayerName = _explorerConfig.View.SortingLayerName;
            _canvas.sortingOrder = _explorerConfig.View.SortingOrder;
        }

        private void SetFontToInputs()
        {
            foreach (var inputField in Objects<TMP_InputField>())
            {
                inputField.fontAsset = _explorerConfig.View.FontAsset;
            }
        }

        private void SetFontToTexts()
        {
            foreach (var textMeshPro in Objects<TextMeshProUGUI>())
            {
                textMeshPro.font = _explorerConfig.View.FontAsset;
            }
        }

        private T[] Objects<T>() where T : Object
        {
            return Object.FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        }
    }
}