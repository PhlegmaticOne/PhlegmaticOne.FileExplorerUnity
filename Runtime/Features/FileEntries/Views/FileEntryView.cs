using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Behaviours;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Views
{
    internal class FileEntryView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;
        [SerializeField] private TextMeshProUGUI _fileNameText;
        [SerializeField] private ButtonHoldBehaviour _holdBehaviour;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _selectionImage;
        
        private FileEntryViewModel _viewModel;
        private RectTransform _headerTransform;

        public void Bind(FileEntryViewModel viewModel)
        {
            _viewModel = viewModel;
            UpdateFileName(viewModel.Name);
            UpdateIcon();
            Subscribe();
        }

        public void UpdateHeaderTransform(RectTransform headerTransform)
        {
            _headerTransform = headerTransform;
        }

        public bool IsBindTo(FileEntryViewModel file)
        {
            return ReferenceEquals(_viewModel, file);
        }

        public void Release()
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