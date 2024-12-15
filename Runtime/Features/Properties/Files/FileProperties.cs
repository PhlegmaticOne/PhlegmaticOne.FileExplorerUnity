using System.IO;
using PhlegmaticOne.FileExplorer.Features.Properties.Core;

namespace PhlegmaticOne.FileExplorer.Features.Properties.Files
{
    internal sealed class FileProperties : FileEntryProperties
    {
        private readonly FileInfo _fileInfo;
        
        public FileProperties(string filePath) : base(new FileInfo(filePath))
        {
            _fileInfo = (FileInfo)FileSystemInfo;
        }

        public override string Type => "File";
        public FileSize Size => new(_fileInfo.Length);
        public string Directory => _fileInfo.DirectoryName;
        public string Extension => _fileInfo.Extension;
    }
}