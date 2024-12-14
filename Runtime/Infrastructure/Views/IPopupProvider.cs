using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal interface IPopupProvider
    {
        Task Show<TPopup, TViewModel>(TViewModel viewModel)
            where TPopup : ViewAsync<TViewModel>
            where TViewModel : ViewModelBase;
    }
}