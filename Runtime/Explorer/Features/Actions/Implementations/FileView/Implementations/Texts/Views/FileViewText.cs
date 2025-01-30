using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views
{
    internal sealed class FileViewText : FileViewBase
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override FileViewType ViewType => FileViewType.Text;

        public override bool Setup(FileViewViewModel viewModel, out string errorMessage)
        {
            var content = viewModel.GetContent<string>();

            if (content.HasError)
            {
                errorMessage = content.ErrorMessage;
                return false;
            }
            
            _text.text = content.Content;
            errorMessage = null;
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