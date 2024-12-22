using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Services.RootObject
{
    internal sealed class ExplorerRootObjectProvider : IExplorerRootObjectProvider
    {
        public ExplorerRootObjectProvider(GameObject rootObject)
        {
            RootObject = rootObject;
        }

        public GameObject RootObject { get; }
    }
}