using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.SafeArea;
using PhlegmaticOne.FileExplorer.States;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerContext : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private MonoContext _context;

        private void Awake()
        {
            var resolution = _canvasScaler.referenceResolution;
            _canvas.worldCamera = Camera.main;
            _canvas.sortingOrder = 999;
            SafeArea.Initialize(resolution.x, resolution.y);
        }

        public void ConstructAndShow()
        {
            _context.Install();
            _context.Resolve<IExplorerStateProvider>().Show();
        }

        private void Update()
        {
            _context.OnUpdate();
        }
    }
}