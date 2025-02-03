using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public class ExplorerAudioExtensionData
    {
        [SerializeField] private string _extension;
        [SerializeField] private AudioType _audioType;

        public ExplorerAudioExtensionData(string extension, AudioType audioType)
        {
            _extension = extension;
            _audioType = audioType;
        }

        public string Extension => _extension;
        public AudioType AudioType => _audioType;
    }
}