using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities.Components
{
    internal sealed class ComponentProgressSetter : MonoBehaviour
    {
        [SerializeField] private RectTransform _parent;
        [SerializeField] private RectTransform _rectTransform;
        
        private ReactiveProperty<float> _property;

        public void Bind(ReactiveProperty<float> property)
        {
            _property = property;
            _property.ValueChanged += UpdateProgress;
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateProgress;
            _property = null;
        }

        private void UpdateProgress(float progress)
        {
            var width = _parent.rect.width * progress;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
    }
}