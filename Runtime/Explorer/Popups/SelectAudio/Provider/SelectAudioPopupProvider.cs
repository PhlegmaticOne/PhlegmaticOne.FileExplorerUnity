using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal sealed class SelectAudioPopupProvider : ISelectAudioPopupProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;

        public SelectAudioPopupProvider(IDependencyContainer container, IPopupProvider popupProvider)
        {
            _container = container;
            _popupProvider = popupProvider;
        }
        
        public async Task<SelectAudioResult> SelectAudioType()
        {
            var viewModel = _container.Instantiate<SelectAudioViewModel>();
            await _popupProvider.Show<SelectAudioPopup, SelectAudioViewModel>(viewModel);
            return new SelectAudioResult(!viewModel.IsDiscarded, viewModel.GetAudioType());
        }
    }
}