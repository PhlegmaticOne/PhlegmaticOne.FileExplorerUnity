using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionsFactoryFile : FileEntryActionsFactory<FileViewModel>
    {
        private readonly IDependencyContainer _container;

        public FileEntryActionsFactoryFile(IDependencyContainer container)
        {
            _container = container;
        }

        public override FileEntryType EntryType => FileEntryType.File;

        protected override IEnumerable<ActionViewModel> GetActions(FileViewModel fileEntry)
        {
            if (fileEntry.Extension.IsViewable(out var viewType))
            {
                yield return ViewFile(fileEntry, viewType, Color.green);
            }

            if (!fileEntry.Extension.HasValue())
            {
                yield return ViewFile(fileEntry, FileViewType.Image, Color.yellow);
                yield return ViewFile(fileEntry, FileViewType.Text, Color.yellow);
            }

#if UNITY_EDITOR
            yield return _container.Instantiate<FileEntryActionOpenExplorer>().WithFileEntry(fileEntry);
#endif
            yield return _container.Instantiate<FileEntryActionRename>().WithFileEntry(fileEntry);
            yield return _container.Instantiate<FileEntryActionProperties>().WithFileEntry(fileEntry);
            yield return _container.Instantiate<FileEntryActionDelete>().WithFileEntry(fileEntry);
        }

        private FileEntryAction ViewFile(FileEntryViewModel fileEntry, FileViewType viewType, Color color)
        {
            return _container.Instantiate<FileEntryActionViewFile>(viewType, color).WithFileEntry(fileEntry);
        }
    }
}