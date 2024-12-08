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
            UpdateFileName();
            UpdateIcon();
            Subscribe();
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
        }

        private void Unsubscribe()
        {
            _holdBehaviour.OnClicked -= HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked -= HoldBehaviourOnHoldClicked;
        }

        private void HoldBehaviourOnHoldClicked()
        {
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

        private void UpdateFileName()
        {
            _fileNameText.text = _viewModel.Name;
        }

        private void UpdateIcon()
        {
            var data = _viewModel.GetIcon();
            _icon.sprite = data.Icon;
            _aspectRatioFitter.aspectRatio = data.Aspect;
        }
    }
}