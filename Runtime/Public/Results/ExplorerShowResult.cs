using System;
using System.Linq;

namespace PhlegmaticOne.FileExplorer
{
    public readonly struct ExplorerShowResult
    {
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
            SelectedFiles = selectedFiles;
        }

        public bool IsShowed { get; }
        public string[] SelectedFiles { get; }

        public string GetSingleSelection()
        {
            return SelectedFiles.FirstOrDefault();
        }
    }
}