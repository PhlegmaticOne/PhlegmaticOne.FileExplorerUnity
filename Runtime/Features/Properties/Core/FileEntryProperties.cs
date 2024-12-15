﻿using System;
using System.Collections.Generic;
using System.IO;

namespace PhlegmaticOne.FileExplorer.Features.Properties.Core
{
    internal abstract class FileEntryProperties
    {
        protected readonly FileSystemInfo FileSystemInfo;

        protected FileEntryProperties(FileSystemInfo fileSystemInfo)
        {
            FileSystemInfo = fileSystemInfo;
        }
        
        public abstract string Type { get; }
        public string Name => FileSystemInfo.Name;
        public string Path => FileSystemInfo.FullName;
        public DateTime CreationTime => FileSystemInfo.CreationTime;
        public DateTime LastAccessTime => FileSystemInfo.LastAccessTime;
        public DateTime LastWriteTime => FileSystemInfo.LastWriteTime;

        public Dictionary<string, string> GetBaseProperties()
        {
            return new Dictionary<string, string>
            {
                { "Type", Type },
                { "Name", Name },
                { "Path", Path },
                { "Created at", CreationTime.ToString("g") },
                { "Last accessed at", LastAccessTime.ToString("g") },
                { "Last written at", LastWriteTime.ToString("g") },
            };
        }
    }
}