using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal abstract class FileEntryActionsFactory<T> : IFileEntryActionsFactory where T : FileEntryViewModel
    {
        public abstract FileEntryType EntryType { get; }

        public IEnumerable<IExplorerAction> GetActions(FileEntryViewModel file)
        {
            if (file is T generic)
            {
                return GetActions(generic);
            }
            
            return Enumerable.Empty<IExplorerAction>();
        }

        protected abstract IEnumerable<IExplorerAction> GetActions(T fileEntry);
    }
}