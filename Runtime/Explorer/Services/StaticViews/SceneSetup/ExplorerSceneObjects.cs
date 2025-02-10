using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup
{
    internal sealed class ExplorerSceneObjects : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MonoBehaviour _rootBehaviour;
        [SerializeField] private GameObject _rootGameObject;

        public Canvas Canvas => _canvas;
        public MonoBehaviour RootBehaviour => _rootBehaviour;
        public GameObject RootGameObject => _rootGameObject;
    }
}