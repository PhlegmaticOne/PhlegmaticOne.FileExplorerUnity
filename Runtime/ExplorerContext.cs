using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Models;
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
            SetupCanvas();
            SetupSafeArea();
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

        private void SetupCanvas()
        {
            _canvas.worldCamera = Camera.main;
            _canvas.sortingOrder = 999;
        }

        private void SetupSafeArea()
        {
            var resolution = _canvasScaler.referenceResolution;
            SafeArea.Initialize(resolution.x, resolution.y);
        }
    }
}