using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts
{
    internal abstract class TextComponent : MonoBehaviour
    {
        public abstract void SetFont(TMP_FontAsset font);
    }
}