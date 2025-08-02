using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepStaticViewsUnbind : IExplorerCloseStep
    {
        private readonly IExplorerStaticViewComponent[] _staticViewComponents;

        public ExplorerCloseStepStaticViewsUnbind(
            IExplorerStaticViewComponent[] staticViewComponents)
        {
            _staticViewComponents = staticViewComponents;
        }
        
        public void ProcessClose()
        {
            foreach (var staticViewComponent in _staticViewComponents)
            {
                staticViewComponent.Unbind();
            }
        }
    }
}