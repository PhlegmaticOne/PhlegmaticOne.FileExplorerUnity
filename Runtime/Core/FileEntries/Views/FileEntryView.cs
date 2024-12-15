using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Behaviours;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.Views
{
    internal class FileEntryView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;
        [SerializeField] private TextMeshProUGUI _fileNameText;
        [SerializeField] private ButtonHoldBehaviour _holdBehaviour;
        
        private FileEntryViewModel _viewModel;

        public void Bind(FileEntryViewModel viewModel)
        {
            _viewModel = viewModel;
            UpdateFileName(viewModel.Name);
            UpdateIcon();
            Subscribe();
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
        }

        private void Subscribe()
        {
            _holdBehaviour.OnClicked += HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked += HoldBehaviourOnHoldClicked;
            _viewModel.Name.ValueChanged += UpdateFileName;
        }

        private void Unsubscribe()
        {
            _holdBehaviour.OnClicked -= HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked -= HoldBehaviourOnHoldClicked;
            _viewModel.Name.ValueChanged -= UpdateFileName;
        }

        private void HoldBehaviourOnHoldClicked()
        {
            UpdateViewModelPosition();
            _viewModel.OnHoldClick();
        }

        private void HoldBehaviourOnClicked()
        {
            _viewModel.OnClick();
        }

        private void ReleaseIcon()
        {
            _icon.sprite = null;
        }

        private void UpdateViewModelPosition()
        {
            var t = (transform as RectTransform)!;
            _viewModel.Position.Update(t.anchoredPosition, t.rect.size);
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
    }
}