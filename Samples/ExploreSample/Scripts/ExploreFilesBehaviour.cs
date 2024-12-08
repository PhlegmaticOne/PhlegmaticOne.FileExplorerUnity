using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.ExploreSample
{
    public class ExploreFilesBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _exploreButton;

        private void Awake()
        {
            _exploreButton.onClick.AddListener(ExploreFiles);
        }

        private void ExploreFiles()
        {
            Explorer.Open();
        }
    }
}