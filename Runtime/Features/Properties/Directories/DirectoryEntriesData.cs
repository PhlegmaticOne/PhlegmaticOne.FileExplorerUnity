namespace PhlegmaticOne.FileExplorer.Features.Properties.Directories
{
    internal readonly struct DirectoryEntriesData
    {
        public DirectoryEntriesData(int directoriesCount, int filesCount)
        {
            DirectoriesCount = directoriesCount;
            FilesCount = filesCount;
        }

        public int DirectoriesCount { get; }
        public int FilesCount { get; }

        public string BuildView()
        {
            return $"Files: {FilesCount}, Directories: {DirectoriesCount}";
        }
    }
}