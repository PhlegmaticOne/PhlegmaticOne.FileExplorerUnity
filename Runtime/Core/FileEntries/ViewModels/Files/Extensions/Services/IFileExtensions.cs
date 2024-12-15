namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions
{
    internal interface IFileExtensions
    {
        bool IsText(string extension);
        bool IsImage(string extension);
    }
}