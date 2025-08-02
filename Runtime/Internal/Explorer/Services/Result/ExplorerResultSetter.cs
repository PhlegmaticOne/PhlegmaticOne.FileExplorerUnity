using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Services.ShowConfiguration;

namespace PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result
{
    internal sealed class ExplorerResultSetter : IExplorerResultSetter
    {
        private readonly IExplorerResultProvider _resultProvider;
        private readonly IExplorerShowConfiguration _showConfiguration;
        private readonly SelectionViewModel _selectionViewModel;

        public ExplorerResultSetter(
            IExplorerResultProvider resultProvider,
            IExplorerShowConfiguration showConfiguration,
            SelectionViewModel selectionViewModel)
        {
            _resultProvider = resultProvider;
            _showConfiguration = showConfiguration;
            _selectionViewModel = selectionViewModel;
        }
        
        public void SetExplorerResult()
        {
            if (_showConfiguration.IsSelectAnyFiles())
            {
                _resultProvider.SetResult(ExplorerShowResult.Showed(GetSelection()));
                return;
            }
            
            _resultProvider.SetResult(ExplorerShowResult.Showed());
        }

        private string[] GetSelection()
        {
            return _selectionViewModel
                .GetSelection()
                .Select(x => x.Path)
                .ToArray();
        }
    }
}