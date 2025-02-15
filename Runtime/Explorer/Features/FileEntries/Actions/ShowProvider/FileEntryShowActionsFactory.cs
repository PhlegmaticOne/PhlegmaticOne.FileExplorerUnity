using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
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