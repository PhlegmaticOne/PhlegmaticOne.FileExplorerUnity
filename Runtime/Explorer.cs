using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public sealed class Explorer : IExplorer
    {
        private readonly IExplorerConfig _config;

        public Explorer(IExplorerConfig config)
        {
            _config = config;
        }
        
        public void Open()
        {
            var context = Resources.Load<ExplorerContext>("Prefabs/FileExplorer");
            var explorerInstance = Object.Instantiate(context);
            explorerInstance.ConstructAndShow(_config);
        }
    }
}