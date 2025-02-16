using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Components
{
    internal sealed class ComponentText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        private ReactiveProperty<string> _property;

        public void Bind(ReactiveProperty<string> property)
        {
            _property = property;
            _property.ValueChanged += SetText;
            SetText(property.Value);
        }

        public void Release()
        {
            _property.ValueChanged -= SetText;
            _property = null;
        }

        private void SetText(string text)
        {
            _text.text = text;
        }
    }
}