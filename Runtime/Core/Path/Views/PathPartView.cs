using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Path.Views
{
    internal sealed class PathPartView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _partText;
        [SerializeField] private GameObject _nextMark;
        [SerializeField] private Button _button;
        
        private PathPartViewModel _viewModel;

        public void Bind(PathPartViewModel viewModel)
        {
            _viewModel = viewModel;
            UpdatePart(viewModel.Part);
            Subscribe();
        }

        public void Release()
        {
            _viewModel.Part.ValueChanged -= UpdatePart;
            _viewModel.IsCurrent.ValueChanged -= UpdateNextMarkActive;
            _button.onClick.RemoveListener(Navigate);
        }

        public bool IsBindTo(PathPartViewModel pathPart)
        {
            return _viewModel == pathPart;
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