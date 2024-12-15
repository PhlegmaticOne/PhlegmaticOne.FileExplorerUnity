using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Properties.Views
{
    internal sealed class PropertiesPopup : ViewAsync<PropertiesViewModel>
    {
        [SerializeField] private PropertyView _propertyViewPrefab;
        [SerializeField] private RectTransform _propertiesParent;
        [SerializeField] private Button _closeButton;

        private List<PropertyView> _propertyViews;
        
        protected override void OnShowing(PropertiesViewModel viewModel)
        {
            _propertyViews = new List<PropertyView>();
            _closeButton.onClick.AddListener(Close);
            SpawnPropertyViews(viewModel);
        }

        public override void Release()
        {
            DestroyPropertyViews();
        }

        private void SpawnPropertyViews(PropertiesViewModel viewModel)
        {
            foreach (var property in viewModel.Properties)
            {
                var propertyView = Instantiate(_propertyViewPrefab, _propertiesParent);
                propertyView.Setup(property.Key, property.Value);
                _propertyViews.Add(propertyView);
            }
        }

        private void DestroyPropertyViews()
        {
            foreach (var propertyView in _propertyViews)
            {
                Destroy(propertyView.gameObject);
            }
            
            _propertyViews.Clear();
            _propertyViews = null;
        }
    }
}