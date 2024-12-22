using PhlegmaticOne.FileExplorer.Core.Navigation.Services;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class LoadingTextView : MonoBehaviour
    {
        [SerializeField] private string _loadingTextValue;
        [SerializeField] private int _pointsCount;
        [SerializeField] private float _changePointDuration;

        private PostfixTextFormatter _formatter;
        private NavigationViewModel _viewModel;

        private float _currentTime;
        private int _previousPoints;

        public void Construct(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void SetActive(bool isActive)
        {
            if (isActive)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            _formatter = new PostfixTextFormatter(_loadingTextValue, '.');
            enabled = true;
            _currentTime = 0;
            UpdatePointsCount(1);
        }

        private void Hide()
        {
            enabled = false;
            _formatter = null;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            
            var currentPoints = (int)(_currentTime / _changePointDuration) % _pointsCount + 1;

            if (_previousPoints != currentPoints)
            {
                UpdatePointsCount(currentPoints);
            }
        }

        private void UpdatePointsCount(int pointsCount)
        {
            var loadingMessage = _formatter.GetFormattedText(pointsCount);
            _previousPoints = pointsCount;
            _viewModel.SetLoadingMessage(loadingMessage);
        }
    }
}