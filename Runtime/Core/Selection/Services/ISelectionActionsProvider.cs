using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Services
{
    internal interface ISelectionActionsProvider
    {
        IEnumerable<IFileEntryAction> GetActions(SelectionViewModel viewModel);
    }
}