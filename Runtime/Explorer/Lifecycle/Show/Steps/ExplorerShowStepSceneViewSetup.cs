using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps
{
    internal sealed class ExplorerShowStepSceneViewSetup : MonoBehaviour, IExplorerShowStep
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MonoBehaviour _rootBehaviour;
        
        private ExplorerConfig _explorerConfig;
        private ExplorerShowParameters _showParameters;

        [ViewInject]
        public void Construct(
            ExplorerShowParameters showParameters,
            ExplorerConfig explorerConfig)
        {
            _showParameters = showParameters;
            _explorerConfig = explorerConfig;
        }

        public void ProcessShow()
        {
            SetupCanvas();
            SetupFont();
        }

        private void SetupCanvas()
        {
            _canvas.worldCamera = _showParameters.GetCamera();
            _canvas.sortingLayerName = _showParameters.SortingLayerName;
            _canvas.sortingOrder = _showParameters.OrderInLayer;
        }

        private void SetupFont()
        {
            foreach (var textComponent in _rootBehaviour.TextsInChild())
            {
                textComponent.SetFont(_explorerConfig.View.FontAsset);
            }
        }
    }
}