using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewPopup : PopupViewAsync<FileViewViewModel>
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _errorText;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Slider _slider;
        [SerializeField] private RectTransform _viewport;
        [SerializeField] private FileViewBase[] _fileViews;

        private FileViewBase _activeView;

        protected override void OnShowing(FileViewViewModel viewModel)
        {
            _nameText.text = viewModel.Name;
            SetupActiveFileView(viewModel);
        }

        public override void Release()
        {
            _slider.onValueChanged.RemoveListener(ResizeFileView);
            _activeView.Release();
            Destroy(_activeView.gameObject);
            _activeView = null;
        }

        private void SetupActiveFileView(FileViewViewModel viewModel)
        {
            _activeView = GetActiveView(viewModel);

            if (_activeView.Setup(viewModel, out var errorMessage))
            {
                _activeView.gameObject.SetActive(true);
                _scrollRect.content = _activeView.transform as RectTransform;
                _scrollRect.horizontalNormalizedPosition = 0;
                _scrollRect.verticalNormalizedPosition = 0;
                SetupSlider(_activeView);
            }
            else
            {
                _errorText.text = errorMessage;
                _errorText.gameObject.SetActive(true);
                _slider.gameObject.SetActive(false);
            }
        }

        private void SetupSlider(FileViewBase fileView)
        {
            _slider.gameObject.SetActive(fileView.HasResizeSlider);
            _slider.minValue = fileView.MinSliderValue;
            _slider.maxValue = fileView.MaxSliderValue;
            _slider.wholeNumbers = fileView.UseIntegerSliderValues;
            _slider.value = fileView.InitialSliderValue;
            _slider.onValueChanged.AddListener(ResizeFileView);
        }

        private void ResizeFileView(float size)
        {
            _activeView.Resize(size);
        }

        private FileViewBase GetActiveView(FileViewViewModel viewModel)
        {
            var view = Array.Find(_fileViews, x => x.ViewType == viewModel.ViewType);
            return Instantiate(view, _viewport, false);
        }
    }
}