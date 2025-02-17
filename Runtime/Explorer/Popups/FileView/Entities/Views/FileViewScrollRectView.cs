using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewScrollRectView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        
        public void Setup(FileViewBase fileView)
        {
            _scrollRect.content = fileView.transform as RectTransform;
            _scrollRect.horizontalNormalizedPosition = 0;
            _scrollRect.verticalNormalizedPosition = 0;
            _scrollRect.horizontal = !fileView.LockScrolling;
            _scrollRect.vertical = !fileView.LockScrolling;
        }
    }
}