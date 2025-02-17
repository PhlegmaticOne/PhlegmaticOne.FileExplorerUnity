using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewText : FileViewBase
    {
        [SerializeField] private TextMeshProUGUI _text;

        protected override void OnInitializing()
        {
            var content = ViewModel.GetContent<string>();
            _text.text = content.Content;
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