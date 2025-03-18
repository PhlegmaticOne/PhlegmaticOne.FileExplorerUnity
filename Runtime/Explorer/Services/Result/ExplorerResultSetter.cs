namespace PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result
{
    internal sealed class ExplorerResultSetter : IExplorerResultSetter
    {
        private readonly IExplorerResultProvider _resultProvider;

        public ExplorerResultSetter(IExplorerResultProvider resultProvider)
        {
            _resultProvider = resultProvider;
        }
        
        public void SetExplorerResult()
        {
            _resultProvider.SetResult(ExplorerShowResult.Showed());
        }
    }
}