using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewAudioProvider : IFileViewAudioProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;
        private readonly IFileAudioLoader _audioLoader;

        public FileViewAudioProvider(
            IDependencyContainer container,
            IPopupProvider popupProvider,
            IFileAudioLoader audioLoader)
        {
            _container = container;
            _popupProvider = popupProvider;
            _audioLoader = audioLoader;
        }
        
        public async Task ViewAudioFile(FileEntryViewModel file, AudioType audioType, CancellationToken token)
        {
            var audioContent = await _audioLoader.LoadClip(file, audioType, token);
            
            var viewModel = _container
                .Instantiate<FileViewViewModel>()
                .SetupAudio(audioContent);
            
            await _popupProvider.Show<FileViewPopup, FileViewViewModel>(viewModel);
        }
    }
}