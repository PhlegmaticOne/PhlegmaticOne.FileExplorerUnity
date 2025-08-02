using PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services.Progress
{
    internal sealed class NavigationProgressSetter : INavigationProgressSetter
    {
        private readonly HeaderInfoViewModel _headerInfoViewModel;
        
        private int _currentCount;

        public NavigationProgressSetter(HeaderInfoViewModel headerInfoViewModel)
        {
            _headerInfoViewModel = headerInfoViewModel;
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
            _headerInfoViewModel.SetProgressActive(isActive);
            _headerInfoViewModel.SetNormalizedProgress(0);
            _currentCount = 0;
        }

        private void UpdateProgress()
        {
            _headerInfoViewModel.SetProgress(GetProgress());
        }

        private float GetProgress()
        {
            return -95f / _currentCount + 100f;
        }
    }
}