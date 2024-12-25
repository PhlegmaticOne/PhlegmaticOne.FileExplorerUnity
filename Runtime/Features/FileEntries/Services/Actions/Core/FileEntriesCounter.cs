using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal struct FileEntriesCounter : IEquatable<FileEntriesCounter>
    {
        public static FileEntriesCounter Zero => new(0, 0);

        public FileEntriesCounter(int directoriesCount, int filesCount)
        {
            DirectoriesCount = directoriesCount;
            FilesCount = filesCount;
        }

        public int DirectoriesCount { get; private set; }
        public int FilesCount { get; private set; }
        public int TotalCount => DirectoriesCount + FilesCount;

        public void AddDelta(int delta, FileEntryType entryType)
        {
            switch (entryType)
            {
                case FileEntryType.File:
                    FilesCount += delta;
                    break;
                case FileEntryType.Directory:
                    DirectoriesCount += delta;
                    break;
            }
        }

        public bool Equals(FileEntriesCounter other)
        {
            return DirectoriesCount == other.DirectoriesCount && FilesCount == other.FilesCount;
        }

        public override bool Equals(object obj)
        {
            return obj is FileEntriesCounter other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DirectoriesCount, FilesCount);
        }
    }
}