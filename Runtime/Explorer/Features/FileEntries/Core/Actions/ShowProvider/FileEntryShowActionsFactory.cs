using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions
{
    internal abstract class FileEntryShowActionsFactory<T> : IFileEntryShowActionsFactory where T : FileEntryViewModel
    {
        public abstract FileEntryType EntryType { get; }

        public IEnumerable<ActionViewModel> GetActions(FileEntryViewModel file)
        {
            if (file is T generic)
            {
                return GetActions(generic);
            }
            
            return Enumerable.Empty<ActionViewModel>();
        }

        protected abstract IEnumerable<ActionViewModel> GetActions(T fileEntry);
    }
}