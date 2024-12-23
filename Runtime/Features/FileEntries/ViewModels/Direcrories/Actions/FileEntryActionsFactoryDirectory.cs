﻿using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories.Actions
{
    internal sealed class FileEntryActionsFactoryDirectory : FileEntryActionsFactory<DirectoryViewModel>
    {
        private readonly IDependencyContainer _container;

        public FileEntryActionsFactoryDirectory(IDependencyContainer container)
        {
            _container = container;
        }

        public override FileEntryType EntryType => FileEntryType.Directory;

        protected override IEnumerable<ActionViewModel> GetActions(DirectoryViewModel fileEntry)
        {
#if UNITY_EDITOR
            yield return _container.Instantiate<FileEntryActionOpenExplorer>().WithFileEntry(fileEntry);
#endif
            yield return _container.Instantiate<FileEntryActionRename>().WithFileEntry(fileEntry);
            yield return _container.Instantiate<FileEntryActionProperties>().WithFileEntry(fileEntry);
            yield return _container.Instantiate<FileEntryActionDelete>().WithFileEntry(fileEntry);
        }
    }
}