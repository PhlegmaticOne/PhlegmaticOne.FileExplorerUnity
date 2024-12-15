using System.Linq;
using PhlegmaticOne.FileExplorer.Configuration;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions
{
    internal sealed class FileExtensions : IFileExtensions
    {
        private readonly FileExplorerConfig _config;

        public FileExtensions(FileExplorerConfig config)
        {
            _config = config;
        }
        
        public bool IsText(string extension)
        {
            return _config.ExtensionsConfig.TextExtensions.Contains(extension);
        }

        public bool IsImage(string extension)
        {
            return _config.ExtensionsConfig.ImageExtensions.Contains(extension);
        }
    }
}