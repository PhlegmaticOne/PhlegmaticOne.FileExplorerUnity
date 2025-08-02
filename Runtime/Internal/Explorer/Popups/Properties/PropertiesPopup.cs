using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertiesPopup : PopupView<PropertiesPopupViewModel>
    {
        [SerializeField] private ComponentCollectionProperties _collectionView;
        [SerializeField] private ComponentText _headerText;

        protected override void OnInitializing()
        {
            _collectionView.Construct(ViewProvider);
            _collectionView.Bind(ViewModel.Properties);
            _headerText.Bind(ViewModel.HeaderText);
            base.OnInitializing();
        }

        public override void Release()
        {
            _collectionView.Release();
            _headerText.Release();
            base.Release();
        }
    }
}