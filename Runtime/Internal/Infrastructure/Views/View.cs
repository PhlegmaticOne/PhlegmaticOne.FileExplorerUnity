using PhlegmaticOne.FileExplorer.Infrastructure.Views.Texts;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class View : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        private bool _isVisible = true;
        
        public RectTransform RectTransform => _rectTransform;

        private void OnValidate()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Initialize(TMP_FontAsset font)
        {
            SetFont(font);
            OnInitializing();
        }

        protected abstract void OnInitializing();

        public void OnVisibleUpdate(bool isVisible)
        {
            if (!_isVisible && isVisible)
            {
                _isVisible = true;
                OnVisible();
                return;
            }

            if (_isVisible && !isVisible)
            {
                _isVisible = false;
                OnInvisible();
            }
        }
        
        protected virtual void OnVisible() { }
        protected virtual void OnInvisible() { }
        
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