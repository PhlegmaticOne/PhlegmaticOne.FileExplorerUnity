using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Properties;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Services.Properties
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