using PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.Destroying
{
    internal sealed class ExplorerDestroyer : IExplorerDestroyer
    {
        private readonly ExplorerSceneObjects _sceneObjects;

        public ExplorerDestroyer(ExplorerSceneObjects sceneObjects)
        {
            _sceneObjects = sceneObjects;
        }

        public void Destroy()
        {
            var rootObject = _sceneObjects.RootGameObject;
            Object.Destroy(rootObject);
        }
    }
}