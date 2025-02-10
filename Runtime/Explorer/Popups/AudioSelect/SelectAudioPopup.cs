using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.AudioSelect
{
    internal sealed class SelectAudioPopup : PopupViewAsync<SelectAudioViewModel>
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private SelectAudioCollectionView _collectionView;
        [SerializeField] private TextMeshProUGUI _selectedExtensionText;
        [SerializeField] private Button _acceptButton;
        
        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _collectionView.Construct(viewProvider);
        }
        
        protected override void OnInitializing()
        {
            _acceptButton.onClick.AddListener(Close);
            base.OnInitializing();
        }

        protected override void OnShowing(SelectAudioViewModel viewModel)
        {
            viewModel.Subscribe();
            _buttonText.text = viewModel.ButtonText;
            _headerText.text = viewModel.HeaderText;
            _collectionView.AddViews(viewModel.Entries);
            viewModel.SelectedExtension.ValueChanged += SetSelectedExtension;
            SetSelectedExtension(viewModel.SelectedExtension);
        }

        public override void Release()
        {
            PopupViewModel.Unsubscribe();
            PopupViewModel.SelectedExtension.ValueChanged += SetSelectedExtension;
            _acceptButton.onClick.RemoveListener(Close);
            _collectionView.ClearViews();
            base.Release();
        }

        private void SetSelectedExtension(string extension)
        {
            _selectedExtensionText.text = extension;
        }
    }
}