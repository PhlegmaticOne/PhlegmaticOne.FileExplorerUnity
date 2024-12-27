using PhlegmaticOne.FileExplorer.Configuration;

namespace PhlegmaticOne.FileExplorer
{
    internal interface IExplorer
    {
        void Open(IExplorerConfig config);
    }
}