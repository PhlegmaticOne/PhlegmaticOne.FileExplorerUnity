using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerContext : MonoBehaviour
    {
        [SerializeField] private MonoContext _context;

        public Task<ExplorerShowResult> ConstructAndShow(IExplorerConfig config)
        {
            _context.Install(container =>
            {
                container.RegisterInstance(config.Value);
            });
            
            _context.Resolve<ExplorerEntryPoint>().Start();
            return _context.Resolve<IExplorerResultProvider>().WaitForResult();
        }

        private void Update()
        {
            _context.OnUpdate();
        }
    }
}