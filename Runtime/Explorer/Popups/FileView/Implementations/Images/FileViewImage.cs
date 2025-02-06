using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewImage : FileViewBase
    {
        [SerializeField] private Image _image;

        private Vector2 _imageSize;
        
        public override FileViewType ViewType => FileViewType.Image;

        public override bool Setup(FileViewViewModel viewModel, out string errorMessage)
        {
            var content = viewModel.GetContent<Sprite>();

            if (content.HasError)
            {
                errorMessage = content.ErrorMessage;
                return false;
            }

            _image.sprite = content.Content;
            _image.SetNativeSize();
            _imageSize = _image.sprite.rect.size;
            errorMessage = null;
            return true;
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