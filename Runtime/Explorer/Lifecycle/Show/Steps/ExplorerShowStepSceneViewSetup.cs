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
        private Camera _viewCamera;

        [ViewInject]
        public void Construct(
            ExplorerConfig explorerConfig,
            Camera viewCamera)
        {
            _viewCamera = viewCamera;
            _explorerConfig = explorerConfig;
        }

        public void ProcessShow()
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
            foreach (var textComponent in _rootBehaviour.TextsInChild())
            {
                textComponent.SetFont(_explorerConfig.View.FontAsset);
            }
        }
    }
}