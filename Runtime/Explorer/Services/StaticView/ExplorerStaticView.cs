using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.StaticView
{
    internal sealed class ExplorerStaticView : MonoBehaviour, IExplorerStaticView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI[] _staticTexts;
        [SerializeField] private TMP_InputField[] _inputFields;
        
        private ExplorerConfig _explorerConfig;
        private Camera _viewCamera;

        [ViewInject]
        public void Construct(ExplorerConfig explorerConfig, Camera viewCamera)
        {
            _viewCamera = viewCamera;
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
            foreach (var inputField in _inputFields)
            {
                inputField.fontAsset = _explorerConfig.View.FontAsset;
            }
        }

        private void SetFontToTexts()
        {
            foreach (var textMeshPro in _staticTexts)
            {
                textMeshPro.font = _explorerConfig.View.FontAsset;
            }
        }
    }
}