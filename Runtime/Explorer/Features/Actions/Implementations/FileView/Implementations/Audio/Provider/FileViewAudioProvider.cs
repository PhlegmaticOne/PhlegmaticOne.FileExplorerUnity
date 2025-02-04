using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileViewAudioProvider : IFileViewAudioProvider
    {
        private readonly IPopupProvider _popupProvider;
        private readonly IFileAudioLoader _audioLoader;

        public FileViewAudioProvider(
            IPopupProvider popupProvider,
            IFileAudioLoader audioLoader)
        {
            _popupProvider = popupProvider;
            _audioLoader = audioLoader;
        }
        
        public async Task ViewAudioFile(FileEntryViewModel file, AudioType audioType, CancellationToken token)
        {
            var audioContent = await _audioLoader.LoadClip(file, audioType, token);
            var fileViewViewModel = FileViewViewModel.Audio(audioContent);
            await _popupProvider.Show<FileViewPopup, FileViewViewModel>(fileViewViewModel);
        }
    }
}