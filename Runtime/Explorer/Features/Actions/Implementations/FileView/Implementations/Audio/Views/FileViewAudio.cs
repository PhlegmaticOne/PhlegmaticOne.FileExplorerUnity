using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Audio;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileViewAudio : FileViewBase
    {
        [SerializeField] private AudioPlayer _audioPlayer;
        
        public override FileViewType ViewType => FileViewType.Audio;
        public override bool HasResizeSlider => false;

        public override bool Setup(FileViewViewModel viewModel, out string errorMessage)
        {
            var content = viewModel.GetContent<AudioClip>();
            
            if (content.HasError)
            {
                errorMessage = content.ErrorMessage;
                return false;
            }
            
            _audioPlayer.StartPlay(content.Content, content.Name);
            errorMessage = null;
            return true;
        }

        public override void Release()
        {
            _audioPlayer.ReleaseAudio();
        }
    }
}