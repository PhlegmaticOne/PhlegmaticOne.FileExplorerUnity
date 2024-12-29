using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class View : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _textComponents;
        
        public void Initialize(TMP_FontAsset font)
        {
            foreach (var textComponent in _textComponents)
            {
                textComponent.font = font;
            }
            
            OnInitializing(font);
        }

        protected abstract void OnInitializing(TMP_FontAsset font);
        public abstract void Release();
    }
}