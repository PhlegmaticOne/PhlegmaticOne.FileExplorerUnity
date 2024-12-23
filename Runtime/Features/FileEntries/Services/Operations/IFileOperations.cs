namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations
{
    internal interface IFileOperations
    {
        void DeleteFile(string path);
        void DeleteDirectory(string path);
        string RenameFile(string path, string newName);
        string RenameDirectory(string path, string newName);
        bool DirectoryExists(string path);
        bool FileExists(string path);
    }
}