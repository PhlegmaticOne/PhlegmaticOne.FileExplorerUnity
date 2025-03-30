using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public sealed class Explorer : IExplorer
    {
        private const string PrefabsFileExplorerPath = "Prefabs/FileExplorer";
        
        private readonly IExplorerConfig _config;

        public Explorer(IExplorerConfig config)
        {
            _config = config;
        }
        
        public async Task<ExplorerShowResult> Open(ExplorerShowParameters parameters)
        {
            try
            {
                var context = await AssetExtensions
                    .LoadFromResourcesAsync<ExplorerContext>(PrefabsFileExplorerPath);

                var instance = await AssetExtensions
                    .InstantiateAsync(context);
            
                return await instance.ConstructAndShow(_config, parameters);
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
                return ExplorerShowResult.NotShowed();
            }
        }
    }
}