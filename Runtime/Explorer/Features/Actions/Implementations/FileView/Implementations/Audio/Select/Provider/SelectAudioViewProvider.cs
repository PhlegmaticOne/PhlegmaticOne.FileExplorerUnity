using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class SelectAudioViewProvider : ISelectAudioViewProvider
    {
        private readonly IPopupProvider _popupProvider;
        private readonly ExplorerConfig _config;

        public SelectAudioViewProvider(IPopupProvider popupProvider, ExplorerConfig config)
        {
            _popupProvider = popupProvider;
            _config = config;
        }
        
        public async Task<SelectAudioViewResult> SelectAudioType()
        {
            var viewModel = new SelectAudioViewModel("Select extension", "Accept", _config);
            await _popupProvider.Show<SelectAudioPopup, SelectAudioViewModel>(viewModel);
            return new SelectAudioViewResult(!viewModel.IsDiscarded, viewModel.GetAudioType());
        }
    }
}