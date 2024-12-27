using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Models;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerContext : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private MonoContext _context;

        private void Awake()
        {
            var resolution = _canvasScaler.referenceResolution;
            SafeArea.Initialize(resolution.x, resolution.y);
        }

        public void ConstructAndShow(IExplorerConfig config)
        {
            _context.Install(container =>
            {
                container.RegisterInstance(config.Value);
            });
            
            _context.Resolve<ExplorerEntryPoint>().Start();
        }

        private void Update()
        {
            _context.OnUpdate();
        }
    }
}