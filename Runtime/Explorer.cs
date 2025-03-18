using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;
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
        
        public async Task Open(CancellationToken token = default)
        {
            var context = await TaskExtensions
                .LoadFromResourcesAsync<ExplorerContext>("Prefabs/FileExplorer", token);

            var instance = await TaskExtensions
                .InstantiateAsync(context, token);
            
            instance.ConstructAndShow(_config);
        }
    }
}