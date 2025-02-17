using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertiesPopup : PopupViewAsync<PropertiesPopupViewModel>
    {
        [SerializeField] private ComponentCollectionProperties _collectionView;
        [SerializeField] private ComponentText _headerText;

        protected override void OnShowing(PropertiesPopupViewModel popupViewModel)
        {
            _collectionView.Construct(ViewProvider);
            _collectionView.Bind(popupViewModel.Properties);
            _headerText.Bind(popupViewModel.HeaderText);
        }

        public override void Release()
        {
            _collectionView.Release();
            _headerText.Release();
            base.Release();
        }
    }
}