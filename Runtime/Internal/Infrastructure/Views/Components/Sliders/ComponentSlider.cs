using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        private ReactiveProperty<float> _property;
        private ICommand _command;
        private bool _isSettingPropertyValue;

        public void Bind(ReactiveProperty<float> property, ICommand command = null, float minValue = 0, float maxValue = 1)
        {
            _command = command;
            _property = property;
            _property.ValueChanged += UpdateSliderValue;
            _slider.onValueChanged.AddListener(UpdatePropertyValue);
            _slider.minValue = minValue;
            _slider.maxValue = maxValue;
            UpdateSliderValue(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateSliderValue;
            _slider.onValueChanged.RemoveListener(UpdatePropertyValue);
            _property = null;
        }

        private void UpdatePropertyValue(float value)
        {
            _isSettingPropertyValue = true;
            _property.SetValueNotify(value);
            _isSettingPropertyValue = false;
            _command?.Execute(value);
        }

        private void UpdateSliderValue(float value)
        {
            if (_isSettingPropertyValue)
            {
                return;
            }
            
            _slider.SetValueWithoutNotify(value);
        }
    }
}