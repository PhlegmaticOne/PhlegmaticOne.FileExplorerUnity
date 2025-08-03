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
        private ExplorerSceneConfiguration _sceneConfiguration;

        [ViewInject]
        public void Construct(
            ExplorerShowConfiguration showConfiguration,
            ExplorerConfig explorerConfig)
        {
            _sceneConfiguration = showConfiguration.SceneConfiguration;
            _explorerConfig = explorerConfig;
        }

        public void ProcessShow()
        {
            SetupCanvas();
            SetupFont();
        }

        private void SetupCanvas()
        {
            _canvas.worldCamera = _sceneConfiguration.GetCamera();
            _canvas.sortingLayerName = _sceneConfiguration.SortingLayerName;
            _canvas.sortingOrder = _sceneConfiguration.OrderInLayer;
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