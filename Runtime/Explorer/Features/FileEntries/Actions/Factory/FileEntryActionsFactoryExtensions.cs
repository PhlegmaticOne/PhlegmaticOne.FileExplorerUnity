using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal static class FileEntryActionsFactoryExtensions
    {
        internal static ActionViewModel Properties(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionProperties>(FileEntryActionKeys.Properties, fileEntry);
        }
        
        internal static ActionViewModel OpenExplorer(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionOpenExplorer>(FileEntryActionKeys.OpenExplorer, fileEntry);
        }
        
        internal static ActionViewModel Rename(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionRename>(FileEntryActionKeys.Rename, fileEntry);
        }
        
        internal static ActionViewModel Delete(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionDelete>(FileEntryActionKeys.Delete, fileEntry);
        }
        
        internal static ActionViewModel ShowImage(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionShowImage>(FileEntryActionKeys.ShowImage, fileEntry);
        }
        
        internal static ActionViewModel ShowText(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionShowText>(FileEntryActionKeys.ShowText, fileEntry);
        }
        
        internal static ActionViewModel ShowAudio(this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionPlayAudio>(FileEntryActionKeys.ShowAudio, fileEntry);
        }
    }
}