using PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class View : MonoBehaviour
    {
        public void Initialize(TMP_FontAsset font)
        {
            SetFont(font);
            OnInitializing();
        }

        protected abstract void OnInitializing();
        public abstract void Release();

        private void SetFont(TMP_FontAsset font)
        {
            foreach (var textComponent in this.TextsInChild())
            {
                textComponent.SetFont(font);
            }
        }
    }
}