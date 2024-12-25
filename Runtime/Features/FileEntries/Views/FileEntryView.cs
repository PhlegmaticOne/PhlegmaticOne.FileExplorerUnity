using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Behaviours;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Views
{
    internal class FileEntryView : View
    {
        [SerializeField] private Image _icon;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;
        [SerializeField] private TextMeshProUGUI _fileNameText;
        [SerializeField] private ButtonHoldBehaviour _holdBehaviour;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _selectionImage;
        
        private FileEntryViewModel _viewModel;
        private RectTransform _headerTransform;

        [ViewInject]
        public void Construct(FileEntryViewModel viewModel, RectTransform headerTransform, ScrollRect scrollRect)
        {
            _holdBehaviour.Construct(scrollRect);
            ViewModel = viewModel;
            _viewModel = viewModel;
            _headerTransform = headerTransform;
        }
        
        public override void Initialize(TMP_FontAsset font)
        {
            _fileNameText.font = font;
            UpdateFileName(_viewModel.Name);
            UpdateIcon();
            Subscribe();
        }

        public override void Release()
        {
            ReleaseIcon();
            Unsubscribe();
            _viewModel = null;
            _headerTransform = null;
        }

        private void Subscribe()
        {
            _holdBehaviour.OnClicked += HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked += HoldBehaviourOnHoldClicked;
            _viewModel.Name.ValueChanged += UpdateFileName;
            _viewModel.IsSelected.ValueChanged += UpdateSelectionView;
            _viewModel.IsActive.ValueChanged += UpdateIsActive;
        }

        private void Unsubscribe()
        {
            _holdBehaviour.OnClicked -= HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked -= HoldBehaviourOnHoldClicked;
            _viewModel.Name.ValueChanged -= UpdateFileName;
            _viewModel.IsSelected.ValueChanged -= UpdateSelectionView;
            _viewModel.IsActive.ValueChanged -= UpdateIsActive;
        }

        private void HoldBehaviourOnHoldClicked()
        {
            _viewModel.OnHoldClick();
        }

        private void HoldBehaviourOnClicked()
        {
            _viewModel.Position.Update(
                _rectTransform.anchoredPosition, 
                _rectTransform.rect.size, 
                _headerTransform.rect.height);
            
            _viewModel.OnClick();
        }

        private void ReleaseIcon()
        {
            _icon.sprite = null;
        }

        private void UpdateSelectionView(bool isSelected)
        {
            _selectionImage.gameObject.SetActive(isSelected);
        }

        private void UpdateFileName(string value)
        {
            _fileNameText.text = value;
        }

        private void UpdateIcon()
        {
            var icon = _viewModel.Icon;
            _icon.sprite = icon.IconSprite;
            _aspectRatioFitter.aspectRatio = icon.Aspect;
        }

        private void UpdateIsActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}