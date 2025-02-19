using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Extensions
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
        
        public bool IsViewable(out FileContentType contentType)
        {
            contentType = GetFileViewType();
            return contentType != FileContentType.None;
        }

        public bool IsText()
        {
            return _fileExtensions.IsText(Value);
        }

        public bool IsImage()
        {
            return _fileExtensions.IsImage(Value);
        }

        public bool IsAudio()
        {
            return _fileExtensions.IsAudio(Value);
        }

        public AudioType GetAudioType()
        {
            return _fileExtensions.GetAudioType(Value);
        }

        private FileContentType GetFileViewType()
        {
            if (IsText())
            {
                return FileContentType.Text;
            }

            if (IsImage())
            {
                return FileContentType.Image;
            }

            if (IsAudio())
            {
                return FileContentType.Audio;
            }

            return FileContentType.None;
        }
    }
}