using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal interface ISelectionActionsProvider
    {
        IEnumerable<ActionViewModel> GetActions(SelectionViewModel viewModel);
    }
}