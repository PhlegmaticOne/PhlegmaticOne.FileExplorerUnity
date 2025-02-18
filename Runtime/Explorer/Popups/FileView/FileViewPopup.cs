using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Popups.FileView.Components;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewPopup : PopupView<FileViewViewModel>
    {
        [SerializeField] private ComponentText _nameText;
        [SerializeField] private FileViewScrollRectView _scrollRect;
        [SerializeField] private TextMeshProUGUI _errorText;
        [SerializeField] private RectTransform _viewport;
        [SerializeField] private RectTransform _sliderParent;

        private IViewContainer<FileViewBase> _activeView;
        private IViewContainer<ComponentFileViewScaleSlider> _slider;

        protected override void OnInitializing()
        {
            _nameText.Bind(ViewModel.Name);
            SetupActiveFileView(ViewModel);
            base.OnInitializing();
        }

        public override void Release()
        {
            _nameText.Release();
            _activeView.Release();
            _slider.Release();
            _activeView = null;
            _slider = null;
        }

        private void SetupActiveFileView(FileViewViewModel viewModel)
        {
            if (!viewModel.HasError())
            {
                _activeView = GetFileView(viewModel);
                _slider = ViewProvider.GetView<ComponentFileViewScaleSlider>(_sliderParent, _activeView.View);
                _scrollRect.Setup(_activeView.View);
            }
            else
            {
                _errorText.text = viewModel.GetErrorMessage();
                _errorText.gameObject.SetActive(true);
            }
        }

        private IViewContainer<FileViewBase> GetFileView(FileViewViewModel viewModel)
        {
            return viewModel.ViewType switch
            {
                FileViewType.Image => ViewProvider.GetView<FileViewImage>(_viewport, viewModel),
                FileViewType.Text => ViewProvider.GetView<FileViewText>(_viewport, viewModel),
                FileViewType.Audio => ViewProvider.GetView<FileViewAudio>(_viewport, viewModel),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}