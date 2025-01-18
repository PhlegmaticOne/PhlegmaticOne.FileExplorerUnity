using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views
{
    internal sealed class PropertyView : View
    {
        [SerializeField] private TextMeshProUGUI _propertyKeyText;
        [SerializeField] private TextMeshProUGUI _propertyValueText;
        
        private PropertyViewModel _viewModel;

        [ViewInject]
        public void Construct(PropertyViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override void OnInitializing()
        {
            _propertyKeyText.text = _viewModel.Name;
            _propertyValueText.text = _viewModel.Value;
        }

        public override void Release()
        {
            _viewModel = null;
        }
    }
}