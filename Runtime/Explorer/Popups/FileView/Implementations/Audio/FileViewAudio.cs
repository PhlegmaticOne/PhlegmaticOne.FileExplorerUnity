using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewAudio : FileViewBase
    {
        [SerializeField] private AudioPlayer _audioPlayer;
        
        protected override void OnInitializing()
        {
            var content = ViewModel.GetContent<AudioClip>();
            PlayAudio(content).Forget();
        }

        public override void Release()
        {
            _audioPlayer.ReleaseAudio();
        }

        private async Task PlayAudio(FileViewContent<AudioClip> content)
        {
            await Task.Delay(20);
            _audioPlayer.StartPlay(content.Content, content.Name);
        }
    }
}