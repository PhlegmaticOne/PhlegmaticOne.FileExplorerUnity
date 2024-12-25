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

        public static ExplorerExtensionsConfig Default => new()
        {
            _textExtensions = new List<string> { ".txt", ".json", ".xml" },
            _imageExtensions = new List<string> { ".jpg", ".png" }
        };

        public IReadOnlyList<string> TextExtensions => _textExtensions;
        public IReadOnlyList<string> ImageExtensions => _imageExtensions;
        
        public void AddTextExtension(string extension)
        {
            _textExtensions.Add(extension);
        }

        public void AddImageExtension(string extension)
        {
            _imageExtensions.Add(extension);
        }
    }
}