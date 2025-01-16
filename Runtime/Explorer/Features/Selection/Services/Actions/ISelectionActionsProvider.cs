using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Services
{
    internal interface ISelectionActionsProvider
    {
        IEnumerable<ActionViewModel> GetActions(SelectionViewModel viewModel);
    }
}