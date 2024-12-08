using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    internal sealed class ExplorerIconsConfig
    {
        [SerializeField] private bool _isPreviewImagesInsteadIcons;
        [SerializeField] private string _iconsWebDirectoryUrl;

        public bool IsPreviewImagesInsteadOfIcons => _isPreviewImagesInsteadIcons;
        public string IconsWebDirectoryUrl => _iconsWebDirectoryUrl;
    }
}