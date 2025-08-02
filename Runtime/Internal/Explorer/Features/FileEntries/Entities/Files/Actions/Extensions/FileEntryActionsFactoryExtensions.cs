using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions;

namespace PhlegmaticOne.FileExplorer.Features.Entities.Files.Actions
{
    internal static class FileEntryActionsFactoryExtensions
    {
        internal static ActionViewModel ShowImage(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionShowImage>(FileActionKeys.ShowImage, fileEntry);
        }
        
        internal static ActionViewModel ShowText(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionShowText>(FileActionKeys.ShowText, fileEntry);
        }
        
        internal static ActionViewModel ShowAudio(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionPlayAudio>(FileActionKeys.ShowAudio, fileEntry);
        }
    }
}