using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Views
{
    internal sealed class PropertyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _propertyKeyText;
        [SerializeField] private TextMeshProUGUI _propertyValueText;

        public void Setup(string propertyKey, string propertyValue)
        {
            _propertyKeyText.text = propertyKey;
            _propertyValueText.text = propertyValue;
        }
    }
}