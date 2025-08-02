using JetBrains.Annotations;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models
{
    internal enum FileEntryType
    {
        [UsedImplicitly]
        None = 0,
        File = 1,
        Directory = 2
    }
}