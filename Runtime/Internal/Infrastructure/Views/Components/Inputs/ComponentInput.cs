using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _input;
        
        private ReactiveProperty<string> _property;
        private ICommand _command;
        private bool _isSettingOutputText;

        public void Bind(ReactiveProperty<string> property, ICommand command = null)
        {
            _command = command;
            _property = property;
            _property.ValueChanged += UpdateInputText;
            _input.onValueChanged.AddListener(UpdateOutputText);
            UpdateInputText(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateInputText;
            _input.onValueChanged.RemoveListener(UpdateOutputText);
            _property = null;
            _command = null;
        }

        private void UpdateOutputText(string text)
        {
            _isSettingOutputText = true;
            _property.SetValueNotify(text);
            _isSettingOutputText = false;
            _command?.Execute(text);
        }

        private void UpdateInputText(string text)
        {
            if (_isSettingOutputText)
            {
                return;
            }
            
            _input.SetTextWithoutNotify(text);
        }
    }
}