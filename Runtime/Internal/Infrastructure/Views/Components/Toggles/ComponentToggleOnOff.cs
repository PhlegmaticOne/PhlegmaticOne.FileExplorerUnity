using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentToggleOnOff : MonoBehaviour
    {
        [SerializeField] private Button _toggleButton;
        [SerializeField] private Image _targetImage;
        [SerializeField] private Sprite _onSprite;
        [SerializeField] private Sprite _offSprite;

        private bool _isSettingOutputValue;
        private ReactiveProperty<bool> _property;
        private ICommand _command;

        private bool _isOn;

        public void Bind(ReactiveProperty<bool> property, ICommand command = null)
        {
            _command = command;
            _property = property;
            _property.ValueChanged += UpdateToggleValue;
            _toggleButton.onClick.AddListener(ChangeIsOnNotify);
            UpdateToggleValue(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateToggleValue;
            _toggleButton.onClick.RemoveListener(ChangeIsOnNotify);
            _property = null;
        }

        private void UpdateToggleValue(bool isOn)
        {
            if (_isSettingOutputValue)
            {
                return;
            }
            
            UpdateIsOn(isOn, notify: false);
        }
        
        private void ChangeIsOnNotify()
        {
            UpdateIsOn(!_isOn, notify: true);
        }

        private void UpdateIsOn(bool isOn, bool notify)
        {
            _isOn = isOn;
            UpdateImage();
            
            if (notify)
            {
                _isSettingOutputValue = true;
                _property.SetValueNotify(_isOn);
                _isSettingOutputValue = false;
                _command?.Execute(isOn);
            }
        }

        private void UpdateImage()
        {
            var sprite = _isOn ? _onSprite : _offSprite;
            _targetImage.sprite = sprite;
        }
    }
}