using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertiesPopup : PopupViewAsync<PropertiesPopupViewModel>
    {
        [SerializeField] private PropertyCollectionView _collectionView;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _collectionView.Construct(viewProvider);
        }

        protected override void OnShowing(PropertiesPopupViewModel popupViewModel)
        {
            _collectionView.AddViews(popupViewModel.Properties);
        }

        public override void Release()
        {
            _collectionView.ClearViews();
            base.Release();
        }
    }
}