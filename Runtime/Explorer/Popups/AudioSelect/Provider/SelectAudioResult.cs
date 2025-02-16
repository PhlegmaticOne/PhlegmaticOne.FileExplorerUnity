﻿using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.AudioSelect
{
    internal readonly struct SelectAudioResult
    {
        public SelectAudioResult(bool isSelected, AudioType selectedAudioType)
        {
            IsSelected = isSelected;
            SelectedAudioType = selectedAudioType;
        }

        public bool IsSelected { get; }
        public AudioType SelectedAudioType { get; }
    }
}