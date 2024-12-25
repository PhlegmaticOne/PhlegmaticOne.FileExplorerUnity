using System.Linq;
using PhlegmaticOne.FileExplorer.Configuration;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions.Services
{
    internal sealed class FileExtensions : IFileExtensions
    {
        private readonly ExplorerConfig _explorerConfig;

        public FileExtensions(ExplorerConfig explorerConfig)
        {
            _explorerConfig = explorerConfig;
        }
        
        public bool IsText(string extension)
        {
            return _explorerConfig.Extensions.TextExtensions.Contains(extension);
        }

        public bool IsImage(string extension)
        {
            return _explorerConfig.Extensions.ImageExtensions.Contains(extension);
        }
    }
}