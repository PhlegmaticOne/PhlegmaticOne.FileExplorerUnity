using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectAll : IActionCommand
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionSelectAll(SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public Task ExecuteAction(CancellationToken token)
        {
            _selectionViewModel.SelectAll();
            return Task.CompletedTask;
        }
    }
}