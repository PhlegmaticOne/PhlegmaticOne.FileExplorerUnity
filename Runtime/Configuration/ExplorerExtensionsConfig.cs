using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    [Serializable]
    internal sealed class ExplorerExtensionsConfig
    {
        [SerializeField] private string[] _textExtensions;
        [SerializeField] private string[] _imageExtensions;

        public string[] TextExtensions => _textExtensions;
        public string[] ImageExtensions => _imageExtensions;
    }
}