using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal sealed class FileEntryIconView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;

        public void Setup(ExplorerIconData iconData)
        {
            _iconImage.sprite = iconData.IconSprite;
            _aspectRatioFitter.aspectRatio = iconData.Aspect;
        }

        public void Release()
        {
            _iconImage.sprite = null;
        }
    }
}