using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Progress.Entities
{
    internal sealed class ProgressViewModel : ViewModel
    {
        public ProgressViewModel()
        {
            IsActive = new ReactiveProperty<bool>();
            Progress = new ReactiveProperty<float>();
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<float> Progress { get; }

        public void SetProgress(float progress)
        {
            SetNormalizedProgress(progress / 100f);
        }

        public void SetNormalizedProgress(float normalizedProgress)
        {
            Progress.SetValueNotify(Mathf.Clamp01(normalizedProgress));
        }
    }
}