using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentViewInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _input;
        
        private ReactiveProperty<string> _property;

        public void Bind(ReactiveProperty<string> property)
        {
            _property = property;
            _property.ValueChanged += UpdateInputText;
            _input.onValueChanged.AddListener(UpdateOutputText);
            UpdateInputText(property.Value);
        }

        public void Unbind()
        {
            _property.ValueChanged -= UpdateInputText;
            _input.onValueChanged.RemoveListener(UpdateOutputText);
            _property = null;
        }

        private void UpdateOutputText(string text)
        {
            _property.SetValueWithoutNotify(text);
        }

        private void UpdateInputText(string text)
        {
            _input.SetTextWithoutNotify(text);
        }
    }
}