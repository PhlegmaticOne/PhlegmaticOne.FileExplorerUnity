using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services.EntriesGenerationPolicies
{
    internal interface IFileEntriesGenerationPolicy
    {
        Task GenerateFileEntriesAtPath(string path, CancellationToken token, 
            Action<IReadOnlyCollection<FileEntryViewModel>> onEntriesGenerated);
    }
}