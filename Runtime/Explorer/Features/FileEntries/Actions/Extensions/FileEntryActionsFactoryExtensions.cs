using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal static class FileEntryActionsFactoryExtensions
    {
        internal static ActionViewModel Properties(
            this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionProperties>(FileEntryActionKeys.Properties, fileEntry);
        }
        
        internal static ActionViewModel OpenExplorer(
            this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionOpenExplorer>(FileEntryActionKeys.OpenExplorer, fileEntry);
        }
        
        internal static ActionViewModel Rename(
            this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionRename>(FileEntryActionKeys.Rename, fileEntry);
        }
        
        internal static ActionViewModel Delete(
            this IFileEntryActionsFactory factory, FileEntryViewModel fileEntry)
        {
            return factory.Create<FileEntryActionDelete>(FileEntryActionKeys.Delete, fileEntry);
        }
    }
}