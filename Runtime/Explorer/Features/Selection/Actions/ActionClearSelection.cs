using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionClearSelection : IActionCommand
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionClearSelection(SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public Task ExecuteAction(CancellationToken token)
        {
            _selectionViewModel.Clear();
            return Task.CompletedTask;
        }
    }
}