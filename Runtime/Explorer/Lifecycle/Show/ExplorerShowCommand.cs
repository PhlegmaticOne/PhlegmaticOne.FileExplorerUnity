using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps;
using PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show
{
    internal sealed class ExplorerShowCommand : IExplorerShowCommand
    {
        private readonly IExplorerShowStep[] _showSteps;
        private readonly IExplorerResultProvider _resultProvider;

        public ExplorerShowCommand(
            IExplorerShowStep[] showSteps,
            IExplorerResultProvider resultProvider)
        {
            _showSteps = showSteps;
            _resultProvider = resultProvider;
        }

        public Task<ExplorerShowResult> ShowWithResult()
        {
            foreach (var showStep in _showSteps)
            {
                showStep.ProcessShow();
            }
            
            return _resultProvider.WaitForResult();
        }
    }
}