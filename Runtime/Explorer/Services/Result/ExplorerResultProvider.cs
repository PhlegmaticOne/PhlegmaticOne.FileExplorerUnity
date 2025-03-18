using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result
{
    internal sealed class ExplorerResultProvider : IExplorerResultProvider
    {
        private readonly TaskCompletionSource<ExplorerShowResult> _completionSource;
        
        public ExplorerResultProvider()
        {
            _completionSource = new TaskCompletionSource<ExplorerShowResult>();
        }
        
        public Task<ExplorerShowResult> WaitForResult()
        {
            return _completionSource.Task;
        }

        public void SetResult(ExplorerShowResult result)
        {
            _completionSource.TrySetResult(result);
        }
    }
}