using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Listeners
{
    internal sealed class LoadingTextListener : IUpdateListener
    {
        private readonly LoadingTextConfig _config;
        private readonly LoadingTextFormatter _textFormatter;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly ScreenMessagesViewModel _screenMessagesViewModel;
        private readonly SearchViewModel _searchViewModel;

        private bool _isActive;
        private float _currentTime;
        private int _previousPoints;

        public LoadingTextListener(
            LoadingTextConfig config, 
            LoadingTextFormatter textFormatter,
            NavigationViewModel navigationViewModel,
            ScreenMessagesViewModel screenMessagesViewModel,
            SearchViewModel searchViewModel)
        {
            _config = config;
            _textFormatter = textFormatter;
            _navigationViewModel = navigationViewModel;
            _screenMessagesViewModel = screenMessagesViewModel;
            _searchViewModel = searchViewModel;
        }

        public void OnUpdate(float deltaTime)
        {
            TrySwitchActiveState();
            UpdateLoadingText(deltaTime);
        }

        private void UpdateLoadingText(float deltaTime)
        {
            if (!_isActive)
            {
                return;
            }
            
            _currentTime += deltaTime;
            var currentPoints = (int)(_currentTime / _config.ChangePointDuration) % _config.PointsCount + 1;

            if (_previousPoints != currentPoints)
            {
                UpdatePointsCount(currentPoints);
            }
        }
        
        private void UpdatePointsCount(int pointsCount)
        {
            var loadingMessage = _textFormatter.GetFormattedText(pointsCount);
            _previousPoints = pointsCount;
            _screenMessagesViewModel.HeaderMessage.SetValueNotify(
                new ScreenMessageData(loadingMessage, Color.green));
        }

        private void TrySwitchActiveState()
        {
            if (_searchViewModel.IsActive)
            {
                _isActive = false;
                _currentTime = 0;
                return;
            }
            
            switch (_isActive)
            {
                case true when !_navigationViewModel.IsLoading:
                    _isActive = false;
                    _currentTime = 0;
                    _screenMessagesViewModel.IsHeaderMessageActive.SetValueNotify(false);
                    return;
                case false when _navigationViewModel.IsLoading:
                    _isActive = true;
                    _currentTime = 0;
                    UpdatePointsCount(1);
                    _screenMessagesViewModel.IsHeaderMessageActive.SetValueNotify(true);
                    break;
            }
        }
    }
}