using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal abstract class FileEntryActionsFactory<T> : IFileEntryActionsFactory where T : FileEntryViewModel
    {
        public IEnumerable<IFileEntryAction> GetActions(FileEntryViewModel fileEntry)
        {
            if (fileEntry is T generic)
            {
                return GetActions(generic);
            }
            
            return Enumerable.Empty<IFileEntryAction>();
        }

        protected abstract IEnumerable<IFileEntryAction> GetActions(T fileEntry);
    }
}