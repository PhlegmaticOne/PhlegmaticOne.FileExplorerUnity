using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Services
{
    internal interface ISelectionActionsProvider
    {
        IEnumerable<IExplorerAction> GetActions(SelectionViewModel viewModel);
    }
}