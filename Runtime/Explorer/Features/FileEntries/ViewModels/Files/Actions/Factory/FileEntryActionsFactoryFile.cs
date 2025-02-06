using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionsFactoryFile : FileEntryActionsFactory<FileViewModel>
    {
        private readonly IDependencyContainer _container;
        private readonly IFileConfidentActionProvider _confidentActionProvider;

        public FileEntryActionsFactoryFile(
            IDependencyContainer container,
            IFileConfidentActionProvider confidentActionProvider)
        {
            _container = container;
            _confidentActionProvider = confidentActionProvider;
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
                yield return _container.Instantiate<FileEntryActionShowImage>(fileEntry);
                yield return _container.Instantiate<FileEntryActionShowText>(fileEntry);
                yield return _container.Instantiate<FileEntryActionPlayAudio>(fileEntry);
            }

#if UNITY_EDITOR
            yield return _container.Instantiate<FileEntryActionOpenExplorer>(fileEntry);
#endif
            yield return _container.Instantiate<FileEntryActionRename>(fileEntry);
            yield return _container.Instantiate<FileEntryActionProperties>(fileEntry);
            yield return _container.Instantiate<FileEntryActionDelete>(fileEntry);
        }
    }
}