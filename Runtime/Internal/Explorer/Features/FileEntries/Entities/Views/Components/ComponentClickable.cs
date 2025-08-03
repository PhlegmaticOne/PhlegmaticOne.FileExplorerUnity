using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal sealed class ComponentClickable : MonoBehaviour
    {
        private const float DisabledAlpha = 0.15f;
        
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private ReactiveProperty<bool> _isClickable;

        public void Bind(ReactiveProperty<bool> isClickable)
        {
            _isClickable = isClickable;
            _isClickable.ValueChanged += UpdateIsClickable;
            UpdateIsClickable(_isClickable.Value);
        }

        public void Release()
        {
            _isClickable.ValueChanged -= UpdateIsClickable;
            _isClickable = null;
        }

        private void UpdateIsClickable(bool isClickable)
        {
            _canvasGroup.alpha = GetAlpha(isClickable);
        }

        private static float GetAlpha(bool isClickable)
        {
            return isClickable ? 1 : DisabledAlpha;
        }
    }
}