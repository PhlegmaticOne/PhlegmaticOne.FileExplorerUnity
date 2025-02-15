using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories.Actions
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