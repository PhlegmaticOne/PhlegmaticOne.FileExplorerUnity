using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Core;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions
{
    internal sealed class FileExtension
    {
        private readonly IFileExtensions _fileExtensions;

        public FileExtension(IFileExtensions fileExtensions, string extension)
        {
            Extension = extension;
            _fileExtensions = fileExtensions;
        }

        public string Extension { get; }
        
        public bool HasValue()
        {
            return !string.IsNullOrEmpty(Extension);
        }
        
        public bool IsViewable(out FileViewType viewType)
        {
            viewType = GetFileViewType();
            return viewType != FileViewType.None;
        }

        public bool IsText()
        {
            return _fileExtensions.IsText(Extension);
        }

        public bool IsImage()
        {
            return _fileExtensions.IsImage(Extension);
        }

        private FileViewType GetFileViewType()
        {
            if (IsText())
            {
                return FileViewType.Text;
            }

            if (IsImage())
            {
                return FileViewType.Image;
            }

            return FileViewType.None;
        }
    }
}