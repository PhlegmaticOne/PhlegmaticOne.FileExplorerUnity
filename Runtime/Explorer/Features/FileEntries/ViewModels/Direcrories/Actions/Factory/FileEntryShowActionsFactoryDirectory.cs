using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories.Actions
{
    internal sealed class FileEntryShowActionsFactoryDirectory : FileEntryShowActionsFactory<DirectoryViewModel>
    {
        private readonly IFileEntryActionsFactory _factory;

        public FileEntryShowActionsFactoryDirectory(IFileEntryActionsFactory factory)
        {
            _factory = factory;
        }

        public override FileEntryType EntryType => FileEntryType.Directory;

        protected override IEnumerable<ActionViewModel> GetActions(DirectoryViewModel fileEntry)
        {
#if UNITY_EDITOR
            yield return _factory.OpenExplorer(fileEntry);
#endif
            yield return _factory.Rename(fileEntry);
            yield return _factory.Properties(fileEntry);
            yield return _factory.Delete(fileEntry);
        }
    }
}