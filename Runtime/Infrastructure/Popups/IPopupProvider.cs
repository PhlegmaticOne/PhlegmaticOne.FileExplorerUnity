using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal interface IPopupProvider
    {
        Task Show<TPopup, TViewModel>(TViewModel viewModel)
            where TPopup : PopupView<TViewModel>
            where TViewModel : PopupViewModel;

        void CloseLastPopup();
    }
}