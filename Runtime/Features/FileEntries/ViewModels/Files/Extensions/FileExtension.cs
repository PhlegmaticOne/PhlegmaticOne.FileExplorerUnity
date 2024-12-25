using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions.Services;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions
{
    internal sealed class FileExtension
    {
        private readonly IFileExtensions _fileExtensions;

        public FileExtension(IFileExtensions fileExtensions, string value)
        {
            Value = value;
            _fileExtensions = fileExtensions;
        }

        public string Value { get; }
        
        public bool HasValue()
        {
            return !string.IsNullOrEmpty(Value);
        }
        
        public bool IsViewable(out FileViewType viewType)
        {
            viewType = GetFileViewType();
            return viewType != FileViewType.None;
        }

        public bool IsText()
        {
            return _fileExtensions.IsText(Value);
        }

        public bool IsImage()
        {
            return _fileExtensions.IsImage(Value);
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