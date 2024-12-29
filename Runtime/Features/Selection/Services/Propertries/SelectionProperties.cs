using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Services
{
    internal readonly struct SelectionProperties
    {
        public SelectionProperties(FileSize selectionSize, FileEntriesCounter entriesCounter)
        {
            SelectionSize = selectionSize;
            EntriesCounter = entriesCounter;
        }

        public FileSize SelectionSize { get; }
        public FileEntriesCounter EntriesCounter { get; }
    }
}