using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views
{
    internal sealed class PropertiesPopup : PopupViewAsync<PropertiesPopupViewModel>
    {
        [SerializeField] private PropertyView _propertyViewPrefab;
        [SerializeField] private RectTransform _propertiesParent;
        [SerializeField] private Button _closeButton;

        private List<PropertyView> _propertyViews;
        
        protected override void OnShowing(PropertiesPopupViewModel popupViewModel)
        {
            _propertyViews = new List<PropertyView>();
            _closeButton.onClick.AddListener(Close);
            SpawnPropertyViews(popupViewModel);
        }

        public override void Release()
        {
            DestroyPropertyViews();
        }

        private void SpawnPropertyViews(PropertiesPopupViewModel popupViewModel)
        {
            foreach (var property in popupViewModel.Properties)
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