using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
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