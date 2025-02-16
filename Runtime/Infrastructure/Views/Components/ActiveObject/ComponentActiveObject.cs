using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentActiveObject : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        private ReactiveProperty<bool> _property;
        private bool _inverse;

        public void Bind(ReactiveProperty<bool> property, bool inverse = false)
        {
            _inverse = inverse;
            _property = property;
            _property.ValueChanged += UpdateObjectActivity;
            UpdateObjectActivity(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateObjectActivity;
            _property = null;
        }

        private void UpdateObjectActivity(bool isActive)
        {
            var resultIsActive = _inverse ? !isActive : isActive;
            _gameObject.SetActive(resultIsActive);
        }
    }
}