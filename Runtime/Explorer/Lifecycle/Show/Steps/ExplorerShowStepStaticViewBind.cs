using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps
{
    internal sealed class ExplorerShowStepStaticViewBind : IExplorerShowStep
    {
        private readonly IExplorerStaticViewComponent[] _viewComponents;

        public ExplorerShowStepStaticViewBind(IExplorerStaticViewComponent[] viewComponents)
        {
            _viewComponents = viewComponents;
        }
        
        public void ProcessShow()
        {
            foreach (var viewComponent in _viewComponents)
            {
                viewComponent.Bind();
            }
        }
    }
}