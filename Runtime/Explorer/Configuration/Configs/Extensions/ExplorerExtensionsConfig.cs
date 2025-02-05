using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerExtensionsConfig
    {
        [SerializeField] private List<string> _textExtensions;
        [SerializeField] private List<string> _imageExtensions;
        [SerializeField] private List<ExplorerAudioExtensionData> _audioExtensions;

        public static ExplorerExtensionsConfig Default => new()
        {
            _textExtensions = new List<string> { ".txt", ".json", ".xml" },
            _imageExtensions = new List<string> { ".jpg", ".png" },
            _audioExtensions = new List<ExplorerAudioExtensionData>
            {
                new(".ogg", AudioType.OGGVORBIS),
                new(".wav", AudioType.WAV),
                new(".aiff", AudioType.AIFF),
                new(".mp3", AudioType.MPEG)
            }
        };

        public IReadOnlyList<ExplorerAudioExtensionData> GetAudioExtensions()
        {
            return _audioExtensions;
        }

        public void AddTextExtension(string extension)
        {
            _textExtensions.Add(extension);
        }

        public void AddImageExtension(string extension)
        {
            _imageExtensions.Add(extension);
        }

        public bool IsImage(string extension)
        {
            return _imageExtensions.Contains(extension);
        }

        public bool IsText(string extension)
        {
            return _textExtensions.Contains(extension);
        }
        
        public bool IsAudio(string extension)
        {
            return _audioExtensions.Exists(x => x.Extension.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }

        public AudioType GetAudioType(string extension)
        {
            return _audioExtensions.Find(x => x.Extension == extension).AudioType;
        }
    }
}