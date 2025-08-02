using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal sealed class SelectAudioPopup : PopupView<SelectAudioViewModel>
    {
        [SerializeField] private ComponentCollectionAudioEntries _collectionView;
        [SerializeField] private ComponentText _selectedExtensionText;
        [SerializeField] private ComponentButton _acceptButton;

        protected override void OnInitializing()
        {
            _collectionView.Construct(ViewProvider);
            ViewModel.SubscribeExtensionsOnSelected();
            _acceptButton.Bind(ViewModel.CloseCommand);
            _collectionView.Bind(ViewModel.Entries);
            _selectedExtensionText.Bind(ViewModel.SelectedExtension);
            base.OnInitializing();
        }

        public override void Release()
        {
            ViewModel.UnsubscribeExtensionsOnSelected();
            _acceptButton.Release();
            _collectionView.Release();
            _selectedExtensionText.Release();
            base.Release();
        }
    }
}