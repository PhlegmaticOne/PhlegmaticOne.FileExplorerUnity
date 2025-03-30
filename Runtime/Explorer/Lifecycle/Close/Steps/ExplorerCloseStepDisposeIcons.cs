using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepDisposeIcons : IExplorerCloseStep
    {
        private readonly IExplorerIconsProvider _iconsProvider;

        public ExplorerCloseStepDisposeIcons(
            IExplorerIconsProvider iconsProvider)
        {
            _iconsProvider = iconsProvider;
        }
        
        public void ProcessClose()
        {
            _iconsProvider.Dispose();
        }
    }
}