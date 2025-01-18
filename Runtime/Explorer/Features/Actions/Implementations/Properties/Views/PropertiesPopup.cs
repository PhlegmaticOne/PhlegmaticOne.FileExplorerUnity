using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views
{
    internal sealed class PropertiesPopup : PopupViewAsync<PropertiesPopupViewModel>
    {
        [SerializeField] private PropertyCollectionView _collectionView;
        [SerializeField] private Button _closeButton;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _collectionView.Construct(viewProvider);
        }

        protected override void OnInitializing()
        {
            _closeButton.onClick.AddListener(Close);
        }

        protected override void OnShowing(PropertiesPopupViewModel popupViewModel)
        {
            _collectionView.AddViews(popupViewModel.Properties);
        }

        public override void Release()
        {
            _closeButton.onClick.RemoveListener(Close);
            _collectionView.ClearViews();
        }
    }
}