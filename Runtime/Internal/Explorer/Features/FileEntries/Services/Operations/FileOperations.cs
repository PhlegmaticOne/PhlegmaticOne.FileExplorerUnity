using System;
using System.IO;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations
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
            var extension = System.IO.Path.GetExtension(path);
            var directoryPath = System.IO.Path.GetDirectoryName(path)!;
            var newPath = System.IO.Path.Combine(directoryPath, newName + extension);

            if (!newPath.Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                File.Delete(newPath);
            }
            
            File.Move(path, newPath);

            return newPath;
        }

        public string RenameDirectory(string path, string newName)
        {
            var parent = Directory.GetParent(path)!.FullName;
            var newPath = System.IO.Path.Combine(parent, newName);

            if (Directory.Exists(newPath))
            {
                Directory.Delete(newPath, true);
            }
            
            Directory.Move(path, newPath);
            return newPath;
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}