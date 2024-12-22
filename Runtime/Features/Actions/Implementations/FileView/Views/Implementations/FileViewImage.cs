using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views.Types
{
    internal sealed class FileViewImage : FileViewBase
    {
        [SerializeField] private Image _image;

        private Vector2 _imageSize;
        
        public override FileViewType ViewType => FileViewType.Image;

        public override bool Setup(FileViewViewModel viewModel, TextMeshProUGUI errorText)
        {
            var content = viewModel.GetSprite();

            if (content.HasError)
            {
                errorText.text = content.ErrorMessage;
                return false;
            }

            _image.sprite = content.Content;
            _image.SetNativeSize();
            _imageSize = _image.sprite.rect.size;
            return true;
        }

        public override void Resize(float size)
        {
            _image.rectTransform.sizeDelta = size * _imageSize;
        }

        public override void Release()
        {
            _image.sprite = null;
        }
    }
}