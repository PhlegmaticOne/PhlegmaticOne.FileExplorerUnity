using PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepSetResult : IExplorerCloseStep
    {
        private readonly IExplorerResultSetter _resultSetter;

        public ExplorerCloseStepSetResult(
            IExplorerResultSetter resultSetter)
        {
            _resultSetter = resultSetter;
        }
        
        public void ProcessClose()
        {
            _resultSetter.SetExplorerResult();
        }
    }
}