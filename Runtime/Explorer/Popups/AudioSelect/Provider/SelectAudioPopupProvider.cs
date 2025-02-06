using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.AudioSelect
{
    internal sealed class SelectAudioPopupProvider : ISelectAudioPopupProvider
    {
        private readonly IPopupProvider _popupProvider;
        private readonly ExplorerConfig _config;

        public SelectAudioPopupProvider(IPopupProvider popupProvider, ExplorerConfig config)
        {
            _popupProvider = popupProvider;
            _config = config;
        }
        
        public async Task<SelectAudioResult> SelectAudioType()
        {
            var viewModel = new SelectAudioViewModel("Select extension", "Accept", _config);
            await _popupProvider.Show<SelectAudioPopup, SelectAudioViewModel>(viewModel);
            return new SelectAudioResult(!viewModel.IsDiscarded, viewModel.GetAudioType());
        }
    }
}