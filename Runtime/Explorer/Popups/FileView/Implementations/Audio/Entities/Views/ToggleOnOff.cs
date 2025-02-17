using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class ToggleOnOff : MonoBehaviour
    {
        [SerializeField] private Button _toggleButton;
        [SerializeField] private Image _targetImage;
        [SerializeField] private Sprite _onSprite;
        [SerializeField] private Sprite _offSprite;

        private readonly List<UnityAction<bool>> _listeners = new();
        private bool _isOn;

        private void Awake()
        {
            _toggleButton.onClick.AddListener(ChangeIsOnNotify);
        }

        public void SetIsOnNotify(bool isOn)
        {
            UpdateIsOn(isOn, notify: true);
        }

        public void SetIsOnWithoutNotify(bool isOn)
        {
            UpdateIsOn(isOn, notify: false);
        }

        public void AddListener(UnityAction<bool> action)
        {
            _listeners.Add(action);
        }

        public void RemoveListener(UnityAction<bool> action)
        {
            _listeners.Remove(action);
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
                RaiseListeners();
            }
        }

        private void UpdateImage()
        {
            var sprite = _isOn ? _onSprite : _offSprite;
            _targetImage.sprite = sprite;
        }

        private void RaiseListeners()
        {
            foreach (var listener in _listeners)
            {
                listener?.Invoke(_isOn);
            }
        }
    }
}