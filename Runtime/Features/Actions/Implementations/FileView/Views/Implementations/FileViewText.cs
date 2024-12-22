using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views.Types
{
    internal sealed class FileViewText : FileViewBase
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override FileViewType ViewType => FileViewType.Text;

        public override bool Setup(FileViewViewModel viewModel, TextMeshProUGUI errorText)
        {
            var content = viewModel.GetText();

            if (content.HasError)
            {
                errorText.text = content.ErrorMessage;
                return false;
            }
            
            _text.text = content.Content;
            return true;
        }

        public override void Resize(float size)
        {
            _text.fontSize = size;
        }

        public override void Release()
        {
        }
    }
}