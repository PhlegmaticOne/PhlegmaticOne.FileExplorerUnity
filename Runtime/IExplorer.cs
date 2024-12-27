using PhlegmaticOne.FileExplorer.Configuration;

namespace PhlegmaticOne.FileExplorer
{
    public interface IExplorer
    {
        void Open(IExplorerConfig config);
    }
}