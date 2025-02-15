using System;
using System.Collections.Generic;
using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Properties;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties
{
    internal abstract class FileEntryProperties
    {
        protected readonly FileSystemInfo FileSystemInfo;

        protected FileEntryProperties(FileSystemInfo fileSystemInfo)
        {
            FileSystemInfo = fileSystemInfo;
        }
        
        public abstract string Type { get; }
        public abstract FileSize Size { get; }
        public string Name => FileSystemInfo.Name;
        public string Path => FileSystemInfo.FullName;
        public DateTime CreationTime => FileSystemInfo.CreationTime;
        public DateTime LastAccessTime => FileSystemInfo.LastAccessTime;
        public DateTime LastWriteTime => FileSystemInfo.LastWriteTime;

        public virtual Dictionary<string, string> GetPropertiesView()
        {
            return new Dictionary<string, string>
            {
                { "Type", Type },
                { "Name", Name },
                { "Path", Path },
                { "Size", Size.BuildUnitView() },
                { "Created at", CreationTime.ToString("g") },
                { "Last accessed at", LastAccessTime.ToString("g") },
                { "Last written at", LastWriteTime.ToString("g") },
            };
        }
    }
}