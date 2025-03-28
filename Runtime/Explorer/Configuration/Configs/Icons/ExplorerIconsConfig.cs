﻿using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerIconsConfig
    {
        private const string DefaultUrl = "https://static.openmygame.com/word_spells/test/krotov_test/Icons/";
        
        [SerializeField] 
        private ExplorerIconsLoadType _iconsLoadType;
        
        [Header("Settings for loading file icons from server")]
        [SerializeField] private string _iconsWebDirectoryUrl;
        [SerializeField, Range(0, 10)] private float _webLoadTimeout;
        
        [SerializeField, HideInInspector] 
        private ExplorerIconsInBuildData _inBuildData;

        internal static ExplorerIconsConfig Default => new()
        {
            _iconsWebDirectoryUrl = DefaultUrl,
            _iconsLoadType = ExplorerIconsLoadType.UseInBuildIconsAlways,
            _webLoadTimeout = 1,
            _inBuildData = new ExplorerIconsInBuildData(
                directoryIconPath: "Sprites/FileIcons/directory",
                fileIconPath: "Sprites/FileIcons/none")
        };

        public ExplorerIconsLoadType IconsLoadType
        {
            get => _iconsLoadType;
            set => _iconsLoadType = value;
        }

        public string IconsWebDirectoryUrl
        {
            get => _iconsWebDirectoryUrl;
            set => _iconsWebDirectoryUrl = value;
        }

        public float WebLoadTimeout
        {
            get => _webLoadTimeout;
            set => _webLoadTimeout = value;
        }

        public ExplorerIconsInBuildData InBuildData
        {
            get => _inBuildData;
            set => _inBuildData = value;
        }
    }
}