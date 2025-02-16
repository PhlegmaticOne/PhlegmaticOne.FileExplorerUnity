using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    internal abstract class TextFontSetter : MonoBehaviour
    {
        public abstract void SetFont(TMP_FontAsset font);
    }
}