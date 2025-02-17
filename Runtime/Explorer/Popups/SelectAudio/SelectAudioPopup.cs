using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal sealed class SelectAudioPopup : PopupViewAsync<SelectAudioViewModel>
    {
        [SerializeField] private ComponentCollectionAudioEntries _collectionView;
        [SerializeField] private ComponentText _selectedExtensionText;
        [SerializeField] private ComponentButton _acceptButton;

        protected override void OnShowing(SelectAudioViewModel viewModel)
        {
            _collectionView.Construct(ViewProvider);
            viewModel.SubscribeExtensionsOnSelected();
            _acceptButton.Bind(viewModel.CloseCommand);
            _collectionView.Bind(viewModel.Entries);
            _selectedExtensionText.Bind(viewModel.SelectedExtension);
        }

        public override void Release()
        {
            PopupViewModel.UnsubscribeExtensionsOnSelected();
            _acceptButton.Release();
            _collectionView.Release();
            _selectedExtensionText.Release();
            base.Release();
        }
    }
}