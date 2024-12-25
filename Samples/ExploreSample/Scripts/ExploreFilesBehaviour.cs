using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.ExploreSample
{
    public class ExploreFilesBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _exploreButton;
        [SerializeField] private ExplorerConfigScriptable _configScriptable;

        private void Awake()
        {
            Application.targetFrameRate = 60; 
            _exploreButton.onClick.AddListener(ExploreFiles);
        }

        private void ExploreFiles()
        {
            Explorer.Open(_configScriptable);
        }
    }
}