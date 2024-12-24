using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    internal sealed class ExplorerIconsConfig
    {
        [SerializeField] private string _iconsWebDirectoryUrl;

        public string IconsWebDirectoryUrl => _iconsWebDirectoryUrl;
    }
}