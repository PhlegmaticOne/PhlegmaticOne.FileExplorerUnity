﻿using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal interface IFileEntryFactory
    {
        FileEntryViewModel CreateEntry(FileSystemInfo fileEntry);
    }
}