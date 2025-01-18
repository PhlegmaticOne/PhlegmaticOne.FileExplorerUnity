using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    [RequireComponent(typeof(TMP_InputField))]
    internal sealed class TextComponentInput : TextComponent
    {
        [SerializeField] private TMP_InputField _input;

        private void OnValidate()
        {
            _input = GetComponent<TMP_InputField>();
        }

        public override void SetFont(TMP_FontAsset font)
        {
            _input.fontAsset = font;
        }
    }
}