using UnityEngine;

namespace PhlegmaticOne.FileExplorer.States.Commands
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