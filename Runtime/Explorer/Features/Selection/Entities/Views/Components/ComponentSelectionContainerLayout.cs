using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Entities.Components
{
    internal sealed class ComponentSelectionContainerLayout : MonoBehaviour
    {
        [SerializeField] private LayoutElement _layoutElement;
        [SerializeField] private float _collapsedPreferredWidth = 80;
        
        private ReactiveProperty<bool> _property;

        public void Bind(ReactiveProperty<bool> property)
        {
            _property = property;
            _property.ValueChanged += UpdateLayout;
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateLayout;
            _property = null;
        }

        private void UpdateLayout(bool isActive)
        {
            if (isActive)
            {
                _layoutElement.flexibleWidth = 1;
                _layoutElement.preferredWidth = -1;
            }
            else
            {
                _layoutElement.flexibleWidth = -1;
                _layoutElement.preferredWidth = _collapsedPreferredWidth;
            }
        }
    }
}