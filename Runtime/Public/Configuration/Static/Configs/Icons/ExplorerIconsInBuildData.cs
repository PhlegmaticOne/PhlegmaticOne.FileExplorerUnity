using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    public sealed class ExplorerIconsInBuildData
    {
        [SerializeField] private string _directoryIconPath;
        [SerializeField] private string _fileIconPath;

        public ExplorerIconsInBuildData(string directoryIconPath, string fileIconPath)
        {
            _directoryIconPath = directoryIconPath;
            _fileIconPath = fileIconPath;
        }

        public string DirectoryIconPath => _directoryIconPath;
        public string FileIconPath => _fileIconPath;
    }
}