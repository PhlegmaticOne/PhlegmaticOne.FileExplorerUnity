using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Positions
{
    internal sealed class ComponentAnchoredPosition : MonoBehaviour
    {
        [SerializeField] private RectTransform _transform;
        
        private ReactiveProperty<Vector3> _property;

        public void Bind(ReactiveProperty<Vector3> property)
        {
            _property = property;
            _property.ValueChanged += SetPosition;
            SetPosition(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= SetPosition;
            _property = null;
        }

        private void SetPosition(Vector3 position)
        {
            _transform.anchoredPosition = position;
        }
    }
}