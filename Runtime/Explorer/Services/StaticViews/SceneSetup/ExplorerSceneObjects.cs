using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup
{
    internal sealed class ExplorerSceneObjects : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MonoBehaviour _rootBehaviour;
        [SerializeField] private GameObject _rootGameObject;
        [SerializeField] private ScrollRect _scrollRect;

        public ScrollRect ScrollRect => _scrollRect;
        public Canvas Canvas => _canvas;
        public MonoBehaviour RootBehaviour => _rootBehaviour;
        public GameObject RootGameObject => _rootGameObject;
    }
}