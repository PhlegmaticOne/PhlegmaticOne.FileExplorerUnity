using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionClearSelection : IAction
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionClearSelection(SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public Task Execute(CancellationToken token)
        {
            _selectionViewModel.Clear();
            return Task.CompletedTask;
        }
    }
}