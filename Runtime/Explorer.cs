using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public class Explorer
    {
        public static void Open(IExplorerConfig config)
        {
            var context = Resources.Load<ExplorerContext>("Prefabs/FileExplorer");
            var explorerInstance = Object.Instantiate(context);
            explorerInstance.ConstructAndShow(config);
        }
    }
}