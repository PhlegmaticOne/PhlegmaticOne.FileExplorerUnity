using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal interface IErrorPopupProvider
    {
        Task ViewError(FileEntryViewModel fileEntry, Exception exception);
        Task ViewError(Exception exception);
    }
}