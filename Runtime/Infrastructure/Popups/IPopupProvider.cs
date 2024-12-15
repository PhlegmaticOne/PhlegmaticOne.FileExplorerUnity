using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal interface IPopupProvider
    {
        Task Show<TPopup, TViewModel>(TViewModel viewModel)
            where TPopup : PopupViewAsync<TViewModel>
            where TViewModel : PopupViewModel;
    }
}