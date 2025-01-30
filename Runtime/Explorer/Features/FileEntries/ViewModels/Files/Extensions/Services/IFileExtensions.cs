namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions.Services
{
    internal interface IFileExtensions
    {
        bool IsText(string extension);
        bool IsImage(string extension);
        bool IsAudio(string extension);
    }
}