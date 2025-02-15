using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentViewActiveObject : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        private ReactiveProperty<bool> _property;

        public void Bind(ReactiveProperty<bool> property)
        {
            _property = property;
            _property.ValueChanged += UpdateObjectActivity;
            UpdateObjectActivity(property.Value);
        }

        public void Unbind()
        {
            _property.ValueChanged -= UpdateObjectActivity;
            _property = null;
        }

        private void UpdateObjectActivity(bool isActive)
        {
            _gameObject.SetActive(isActive);
        }
    }
}