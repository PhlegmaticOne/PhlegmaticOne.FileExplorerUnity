using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Lifecycle.Show;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerContext : MonoBehaviour
    {
        [SerializeField] private MonoContext _context;

        public Task<ExplorerShowResult> ConstructAndShow(IExplorerConfig config, ExplorerShowConfiguration configuration)
        {
            _context.Install(container =>
            {
                container.RegisterInstance(config.Value);
                container.RegisterInstance(configuration);
            });

            return _context
                .Resolve<IExplorerShowCommand>()
                .ShowWithResult();
        }
    }
}