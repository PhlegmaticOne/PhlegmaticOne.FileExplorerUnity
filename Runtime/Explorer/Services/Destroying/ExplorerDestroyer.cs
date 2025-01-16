using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.Destroying
{
    internal sealed class ExplorerDestroyer : IExplorerDestroyer
    {
        private readonly GameObject _rootObject;

        public ExplorerDestroyer(GameObject rootObject)
        {
            _rootObject = rootObject;
        }

        public void Destroy()
        {
            Object.Destroy(_rootObject);
        }
    }
}