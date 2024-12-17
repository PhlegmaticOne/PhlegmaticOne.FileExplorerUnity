namespace PhlegmaticOne.FileExplorer.Core.FileEntries
{
    internal struct FileEntriesCounter
    {
        public static FileEntriesCounter Zero => new(0, 0);

        public FileEntriesCounter(int directoriesCount, int filesCount)
        {
            DirectoriesCount = directoriesCount;
            FilesCount = filesCount;
        }

        public int DirectoriesCount { get; private set; }
        public int FilesCount { get; private set; }

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
    }
}