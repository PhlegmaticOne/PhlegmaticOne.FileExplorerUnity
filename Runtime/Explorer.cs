using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using TaskExtensions = PhlegmaticOne.FileExplorer.Infrastructure.Extensions.TaskExtensions;

namespace PhlegmaticOne.FileExplorer
{
    public sealed class Explorer : IExplorer
    {
        private readonly IExplorerConfig _config;

        public Explorer(IExplorerConfig config)
        {
            _config = config;
        }
        
        public async Task<ExplorerShowResult> Open(CancellationToken token = default)
        {
            try
            {
                var context = await TaskExtensions
                    .LoadFromResourcesAsync<ExplorerContext>("Prefabs/FileExplorer", token);

                var instance = await TaskExtensions
                    .InstantiateAsync(context, token);
            
                return await instance.ConstructAndShow(_config);
            }
            catch
            {
                return ExplorerShowResult.NotShowed();
            }
        }
    }
}