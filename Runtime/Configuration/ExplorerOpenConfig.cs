using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerOpenConfig
    {
        [SerializeField] private bool _isPreviewImagesInsteadIcons;
        [SerializeField] private string _startupLocation;

        public ExplorerOpenConfig() : this(Application.persistentDataPath, false) { }

        public ExplorerOpenConfig(string startupLocation, bool isPreviewImagesInsteadIcons = false)
        {
            _startupLocation = startupLocation.PathSlash();
            _isPreviewImagesInsteadIcons = isPreviewImagesInsteadIcons;
        }

        public bool IsPreviewImagesInsteadOfIcons
        {
            get => _isPreviewImagesInsteadIcons;
            set => _isPreviewImagesInsteadIcons = value;
        }

        public string StartupLocation
        {
            get => _startupLocation;
            set => _startupLocation = value.PathSlash();
        }
    }
}