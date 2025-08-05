using System;
using System.Linq;

namespace PhlegmaticOne.FileExplorer
{
    public readonly struct ExplorerShowResult
    {
        private readonly string[] _selectedFiles;

        public static ExplorerShowResult Showed(string[] selectedFiles = null)
        {
            return new ExplorerShowResult(isShowed: true, selectedFiles ?? Array.Empty<string>());
        }
        
        public static ExplorerShowResult NotShowed()
        {
            return new ExplorerShowResult(isShowed: false, Array.Empty<string>());
        }

        private ExplorerShowResult(bool isShowed, string[] selectedFiles)
        {
            IsShowed = isShowed;
            _selectedFiles = selectedFiles;
        }

        public bool IsShowed { get; }

        public bool TryGetSelection(out string[] selection)
        {
            selection = _selectedFiles;
            return _selectedFiles.Length > 0;
        }

        public bool TryGetSingleSelection(out string selection)
        {
            selection = _selectedFiles.FirstOrDefault();
            return _selectedFiles.Length > 0;
        }
    }
}