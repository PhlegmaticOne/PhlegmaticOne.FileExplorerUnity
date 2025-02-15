using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.Entities.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions
{
    internal sealed class FileEntryShowActionsFactoryFile : FileEntryShowActionsFactory<FileViewModel>
    {
        private readonly IFileConfidentActionProvider _confidentActionProvider;
        private readonly IFileEntryActionsFactory _factory;

        public FileEntryShowActionsFactoryFile(
            IFileConfidentActionProvider confidentActionProvider,
            IFileEntryActionsFactory factory)
        {
            _confidentActionProvider = confidentActionProvider;
            _factory = factory;
        }

        public override FileEntryType EntryType => FileEntryType.File;

        protected override IEnumerable<ActionViewModel> GetActions(FileViewModel fileEntry)
        {
            if (_confidentActionProvider.TryGetConfidentAction(fileEntry, out var action))
            {
                yield return action;
            }
            
            if (!fileEntry.Extension.HasValue())
            {
                yield return _factory.ShowImage(fileEntry);
                yield return _factory.ShowText(fileEntry);
                yield return _factory.ShowAudio(fileEntry);
            }

#if UNITY_EDITOR
            yield return _factory.OpenExplorer(fileEntry);
#endif
            yield return _factory.Rename(fileEntry);
            yield return _factory.Properties(fileEntry);
            yield return _factory.Delete(fileEntry);
        }
    }
}