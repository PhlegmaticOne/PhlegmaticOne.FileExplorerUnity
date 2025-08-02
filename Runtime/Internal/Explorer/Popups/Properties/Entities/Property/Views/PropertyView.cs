using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertyView : View
    {
        [SerializeField] private ComponentText _propertyKeyText;
        [SerializeField] private ComponentText _propertyValueText;
        
        private PropertyViewModel _viewModel;

        [ViewInject]
        public void Construct(PropertyViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override void OnInitializing()
        {
            _propertyKeyText.Bind(_viewModel.Name);
            _propertyValueText.Bind(_viewModel.Value);
        }

        public override void Release()
        {
            _propertyKeyText.Release();
            _propertyValueText.Release();
            _viewModel = null;
        }
    }
}