using System.Collections.Generic;
using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Services.Proprties;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Properties
{
    internal sealed class FileProperties : FileEntryProperties
    {
        private readonly FileInfo _fileInfo;
        
        public FileProperties(string filePath) : base(new FileInfo(filePath))
        {
            _fileInfo = (FileInfo)FileSystemInfo;
        }

        public override string Type => "File";
        public override FileSize Size => new(_fileInfo.Length);
        public string Directory => _fileInfo.DirectoryName;
        public string Extension => _fileInfo.Extension;

        public override Dictionary<string, string> GetPropertiesView()
        {
            var properties = base.GetPropertiesView();
            properties.Add("Directory", Directory);
            properties.Add("Extension", Extension);
            return properties;
        }
    }
}