﻿using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
{
    internal interface IFileEntryAction
    {
        Task Execute(FileEntryViewModel fileEntry, CancellationToken token);
    }
}