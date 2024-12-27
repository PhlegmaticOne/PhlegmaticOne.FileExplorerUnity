using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerContext : MonoBehaviour
    {
        [SerializeField] private MonoContext _context;

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