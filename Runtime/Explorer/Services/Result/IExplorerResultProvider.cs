using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result
{
    internal interface IExplorerResultProvider
    {
        Task<ExplorerShowResult> WaitForResult();
        void SetResult(ExplorerShowResult result);
    }
}