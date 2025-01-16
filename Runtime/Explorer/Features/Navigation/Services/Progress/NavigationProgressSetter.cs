using PhlegmaticOne.FileExplorer.Features.Progress.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services
{
    internal sealed class NavigationProgressSetter : INavigationProgressSetter
    {
        private readonly ProgressViewModel _progressViewModel;
        
        private int _currentCount;

        public NavigationProgressSetter(ProgressViewModel progressViewModel)
        {
            _progressViewModel = progressViewModel;
        }
        
        public void AddDeltaProgress(int delta)
        {
            _currentCount = Mathf.Clamp(_currentCount + delta, 0, int.MaxValue);
            UpdateProgress();
        }

        public void Complete()
        {
            _currentCount = int.MaxValue;
            UpdateProgress();
        }

        public void SetActive(bool isActive)
        {
            _progressViewModel.IsActive.SetValueNotify(isActive);
            _progressViewModel.SetNormalizedProgress(0);
            _currentCount = 0;
        }

        private void UpdateProgress()
        {
            _progressViewModel.SetProgress(GetProgress());
        }

        private float GetProgress()
        {
            return -95f / _currentCount + 100f;
        }
    }
}