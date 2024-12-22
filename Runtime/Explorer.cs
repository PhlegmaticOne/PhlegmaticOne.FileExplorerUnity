using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public class Explorer
    {
        public static void Open()
        {
            var context = Resources.Load<ExplorerContext>("Prefabs/FileExplorer");
            var explorerInstance = Object.Instantiate(context);
            explorerInstance.ConstructAndShow();
        }
    }
}