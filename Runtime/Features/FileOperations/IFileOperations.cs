namespace PhlegmaticOne.FileExplorer.Features.FileOperations
{
    internal interface IFileOperations
    {
        void DeleteFile(string path);
        void DeleteDirectory(string path);
        string RenameFile(string path, string newName);
        string RenameDirectory(string path, string newName);
    }
}