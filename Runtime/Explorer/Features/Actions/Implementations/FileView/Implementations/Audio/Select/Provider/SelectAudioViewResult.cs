using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal struct SelectAudioViewResult
    {
        public SelectAudioViewResult(bool isSelected, AudioType selectedAudioType)
        {
            IsSelected = isSelected;
            SelectedAudioType = selectedAudioType;
        }

        public bool IsSelected { get; }
        public AudioType SelectedAudioType { get; }
    }
}