using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    internal sealed class TextViewText : TextView
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void OnValidate()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public override void SetFont(TMP_FontAsset font)
        {
            _text.font = font;
        }
    }
}