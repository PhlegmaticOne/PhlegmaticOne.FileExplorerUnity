using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentToggle : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        
        private ReactiveProperty<bool> _property;
        private ICommand _command;
        private bool _isSettingOutputValue;

        public void Bind(ReactiveProperty<bool> property, ICommand command = null)
        {
            _command = command;
            _property = property;
            _property.ValueChanged += UpdateToggleValue;
            _toggle.onValueChanged.AddListener(UpdatePropertyAndCommand);
            UpdateToggleValue(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateToggleValue;
            _toggle.onValueChanged.RemoveListener(UpdatePropertyAndCommand);
            _property = null;
            _command = null;
        }

        private void UpdatePropertyAndCommand(bool isActive)
        {
            _isSettingOutputValue = true;
            _property.SetValueNotify(isActive);
            _isSettingOutputValue = false;
            _command?.Execute(isActive);
        }

        private void UpdateToggleValue(bool isActive)
        {
            if (_isSettingOutputValue)
            {
                return;
            }
            
            _toggle.SetIsOnWithoutNotify(isActive);
        }
    }
}