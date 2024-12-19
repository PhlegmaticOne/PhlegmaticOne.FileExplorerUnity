using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories
{
    internal sealed class FileEntryActionsFactoryDirectory : FileEntryActionsFactory<DirectoryViewModel>
    {
        private readonly IDependencyContainer _container;

        public FileEntryActionsFactoryDirectory(IDependencyContainer container)
        {
            _container = container;
        }

        public override FileEntryType EntryType => FileEntryType.Directory;

        protected override IEnumerable<IExplorerAction> GetActions(DirectoryViewModel fileEntry)
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