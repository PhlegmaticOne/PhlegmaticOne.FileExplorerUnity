using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities
{
    internal sealed class HeaderInfoViewModel : ViewModel
    {
        public HeaderInfoViewModel()
        {
            IsActive = new ReactiveProperty<bool>();
            Progress = new ReactiveProperty<float>();
            InfoMessage = new ReactiveProperty<string>(string.Empty);
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<float> Progress { get; }
        public ReactiveProperty<string> InfoMessage { get; }

        public void SetInfoMessage(string message)
        {
            InfoMessage.SetValueNotify(message);
        }

        public void SetProgressActive(bool isActive)
        {
            IsActive.SetValueNotify(isActive);
        }
        
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