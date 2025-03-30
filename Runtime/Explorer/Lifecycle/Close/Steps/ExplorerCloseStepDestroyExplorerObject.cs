using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepDestroyExplorerObject : MonoBehaviour, IExplorerCloseStep
    {
        [SerializeField] private GameObject _rootObject;
        
        public void ProcessClose()
        {
            Destroy(_rootObject);
        }
    }
}