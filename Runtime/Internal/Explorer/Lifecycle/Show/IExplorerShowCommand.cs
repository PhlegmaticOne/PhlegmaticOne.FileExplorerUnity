using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show
{
    internal interface IExplorerShowCommand
    {
        Task<ExplorerShowResult> ShowWithResult();
    }
}