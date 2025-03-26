using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;

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
                var context = await AssetExtensions
                    .LoadFromResourcesAsync<ExplorerContext>("Prefabs/FileExplorer", token);

                var instance = await AssetExtensions
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