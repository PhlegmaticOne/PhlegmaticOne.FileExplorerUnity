using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerIconsConfig
    {
        private const string DefaultUrl = "https://static.openmygame.com/word_spells/test/krotov_test/Icons/";
        
        [SerializeField] private string _iconsWebDirectoryUrl;
        [SerializeField] private bool _isPreviewImagesInsteadOfIcons;

        internal static ExplorerIconsConfig Default => new()
        {
            _iconsWebDirectoryUrl = DefaultUrl,
            _isPreviewImagesInsteadOfIcons = false
        };

        public bool IsPreviewImagesInsteadOfIcons
        {
            get => _isPreviewImagesInsteadOfIcons;
            set => _isPreviewImagesInsteadOfIcons = value;
        }

        public string IconsWebDirectoryUrl
        {
            get => _iconsWebDirectoryUrl;
            set => _iconsWebDirectoryUrl = value;
        }
    }
}