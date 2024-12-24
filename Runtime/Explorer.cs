using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public class Explorer
    {
        public static void Open()
        {
            Open(new ExplorerOpenConfig());
        }

        public static void Open(ExplorerOpenConfig openConfig)
        {
            var context = Resources.Load<ExplorerContext>("Prefabs/FileExplorer");
            var explorerInstance = Object.Instantiate(context);
            explorerInstance.ConstructAndShow(openConfig);
        }
    }
}