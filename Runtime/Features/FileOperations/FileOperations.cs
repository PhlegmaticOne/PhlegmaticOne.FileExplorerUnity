using System.IO;

namespace PhlegmaticOne.FileExplorer.Features.FileOperations
{
    internal sealed class FileOperations : IFileOperations
    {
        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }

        public string RenameFile(string path, string newName)
        {
            var extension = Path.GetExtension(path);
            var directoryPath = Path.GetDirectoryName(path)!;
            var newPath = Path.Combine(directoryPath, newName + extension);

            File.Delete(newPath);
            File.Move(path, newPath);

            return newPath;
        }

        public string RenameDirectory(string path, string newName)
        {
            var parent = Directory.GetParent(path)!.FullName;
            var newPath = Path.Combine(parent, newName);

            if (Directory.Exists(newPath))
            {
                Directory.Delete(newPath, true);
            }
            
            Directory.Move(path, newPath);
            return newPath;
        }
    }
}