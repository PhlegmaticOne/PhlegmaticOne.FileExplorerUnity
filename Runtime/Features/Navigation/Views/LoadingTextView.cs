using PhlegmaticOne.FileExplorer.Features.Navigation.Services;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Views
{
    internal sealed class LoadingTextView : MonoBehaviour, IUpdateListener
    {
        [SerializeField] private string _loadingTextValue;
        [SerializeField] private int _pointsCount;
        [SerializeField] private float _changePointDuration;

        private PostfixTextFormatter _formatter;
        private NavigationViewModel _viewModel;

        private float _currentTime;
        private int _previousPoints;
        private bool _isActive;

        [ViewInject]
        public void Construct(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
            
            if (_isActive)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_isActive)
            {
                return;
            }
            
            _currentTime += deltaTime;
            var currentPoints = (int)(_currentTime / _changePointDuration) % _pointsCount + 1;

            if (_previousPoints != currentPoints)
            {
                UpdatePointsCount(currentPoints);
            }
        }

        private void Show()
        {
            _formatter = new PostfixTextFormatter(_loadingTextValue, '.');
            _currentTime = 0;
            UpdatePointsCount(1);
        }

        private void Hide()
        {
            _formatter = null;
        }
        
        private void UpdatePointsCount(int pointsCount)
        {
            var loadingMessage = _formatter.GetFormattedText(pointsCount);
            _previousPoints = pointsCount;
            _viewModel.SetLoadingMessage(loadingMessage);
        }
    }
}