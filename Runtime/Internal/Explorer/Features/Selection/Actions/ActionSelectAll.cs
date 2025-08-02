using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectAll : IAction
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionSelectAll(SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public Task Execute(CancellationToken token)
        {
            _selectionViewModel.SelectAll();
            return Task.CompletedTask;
        }
    }
}