using System.IO;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Directories
{
    internal sealed class DirectoryProperties : FileEntryProperties
    {
        private readonly DirectoryInfo _directoryInfo;
        
        public DirectoryProperties(string path) : base(new DirectoryInfo(path))
        {
            _directoryInfo = (DirectoryInfo)FileSystemInfo;
        }

        public override string Type => "Directory";
        
        public FileSize Size => new(GetDirectorySize());

        public DirectoryEntriesData EntriesData => CalculateEntries();

        private long GetDirectorySize()
        {
            long size = 0;
            
            foreach (var file in _directoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                size += file.Length;
            }

            return size;
        }

        private DirectoryEntriesData CalculateEntries()
        {
            int filesCount = 0, directoriesCount = 0;

            foreach (var fileSystemInfo in _directoryInfo.EnumerateFileSystemInfos("*", SearchOption.AllDirectories))
            {
                if (fileSystemInfo is DirectoryInfo)
                {
                    directoriesCount++;
                }
                else
                {
                    filesCount++;
                }
            }

            return new DirectoryEntriesData(directoriesCount, filesCount);
        }
    }
}