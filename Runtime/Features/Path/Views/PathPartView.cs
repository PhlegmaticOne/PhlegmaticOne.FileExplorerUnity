using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Path.Views
{
    internal sealed class PathPartView : View
    {
        [SerializeField] private TextMeshProUGUI _partText;
        [SerializeField] private GameObject _nextMark;
        [SerializeField] private Button _button;
        
        private PathPartViewModel _viewModel;

        [ViewInject]
        public void Construct(PathPartViewModel viewModel)
        {
            _viewModel = viewModel;
            ViewModel = viewModel;
        }

        public override void Initialize(TMP_FontAsset font)
        {
            _partText.font = font;
            UpdatePart(_viewModel.Part);
            Subscribe();
        }

        public override void Release()
        {
            _viewModel.Part.ValueChanged -= UpdatePart;
            _viewModel.IsCurrent.ValueChanged -= UpdateNextMarkActive;
            _button.onClick.RemoveListener(Navigate);
        }

        private void Subscribe()
        {
            _viewModel.Part.ValueChanged += UpdatePart;
            _viewModel.IsCurrent.ValueChanged += UpdateNextMarkActive;
            _button.onClick.AddListener(Navigate);
        }

        private void Navigate()
        {
            _viewModel.Navigate();
        }

        private void UpdatePart(string part)
        {
            _partText.text = part;
        }

        private void UpdateNextMarkActive(bool isCurrent)
        {
            _nextMark.SetActive(!isCurrent);
        }
    }
}