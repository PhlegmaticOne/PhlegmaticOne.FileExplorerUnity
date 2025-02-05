using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions.Services
{
    internal sealed class FileExtensions : IFileExtensions
    {
        private readonly ExplorerConfig _explorerConfig;

        public FileExtensions(ExplorerConfig explorerConfig)
        {
            _explorerConfig = explorerConfig;
        }

        public AudioType GetAudioType(string extension)
        {
            return _explorerConfig.Extensions.GetAudioType(extension);
        }

        public bool IsText(string extension)
        {
            return _explorerConfig.Extensions.IsText(extension);
        }

        public bool IsImage(string extension)
        {
            return _explorerConfig.Extensions.IsImage(extension);
        }

        public bool IsAudio(string extension)
        {
            return _explorerConfig.Extensions.IsAudio(extension);
        }
    }
}