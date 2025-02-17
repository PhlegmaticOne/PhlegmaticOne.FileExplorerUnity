using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Popups.FileView.Components;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewPopup : PopupViewAsync<FileViewViewModel>
    {
        [SerializeField] private ComponentText _nameText;
        [SerializeField] private FileViewScrollRectView _scrollRect;
        [SerializeField] private TextMeshProUGUI _errorText;
        [SerializeField] private RectTransform _viewport;
        [SerializeField] private RectTransform _sliderParent;

        private FileViewBase _activeView;
        private ComponentFileViewScaleSlider _slider;

        protected override void OnShowing(FileViewViewModel viewModel)
        {
            _nameText.Bind(viewModel.Name);
            SetupActiveFileView(viewModel);
        }

        public override void Release()
        {
            _nameText.Release();
            ViewProvider.ReleaseView(_activeView);
            ViewProvider.ReleaseView(_slider);
            _activeView = null;
        }

        private void SetupActiveFileView(FileViewViewModel viewModel)
        {
            if (!viewModel.HasError())
            {
                _activeView = GetFileView(viewModel);
                _slider = ViewProvider.GetView<ComponentFileViewScaleSlider>(_sliderParent).View;
                _scrollRect.Setup(_activeView);
                _slider.Bind(_activeView);
            }
            else
            {
                _errorText.text = viewModel.GetErrorMessage();
                _errorText.gameObject.SetActive(true);
            }
        }

        private FileViewBase GetFileView(FileViewViewModel viewModel)
        {
            return viewModel.ViewType switch
            {
                FileViewType.Image => ViewProvider.GetView<FileViewImage>(_viewport, viewModel).View,
                FileViewType.Text => ViewProvider.GetView<FileViewText>(_viewport, viewModel).View,
                FileViewType.Audio => ViewProvider.GetView<FileViewAudio>(_viewport, viewModel).View,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}