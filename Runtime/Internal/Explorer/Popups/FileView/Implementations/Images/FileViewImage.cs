using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewImage : FileViewBase
    {
        [SerializeField] private Image _image;

        private Vector2 _imageSize;
        
        protected override void OnInitializing()
        {
            var content = ViewModel.GetContent<Sprite>();
            _image.sprite = content.Content;
            _image.SetNativeSize();
            _imageSize = _image.sprite.rect.size;
        }

        public override void Resize(float size)
        {
            _image.rectTransform.sizeDelta = size * _imageSize;
        }

        public override void Release()
        {
            var sprite = _image.sprite;
            sprite.Dispose();
            _image.sprite = null;
        }
    }
}