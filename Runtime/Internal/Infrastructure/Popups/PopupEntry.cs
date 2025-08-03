using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal sealed class PopupEntry
    {
        public PopupEntry(IViewContainer<PopupView> viewContainer, PopupViewModel viewModel)
        {
            ViewContainer = viewContainer;
            ViewModel = viewModel;
        }

        public IViewContainer<PopupView> ViewContainer { get; }
        public PopupViewModel ViewModel { get; }

        public PopupView GetView()
        {
            return ViewContainer.View;
        }
    }
}