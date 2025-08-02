using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewAudio : FileViewBase
    {
        [SerializeField] private AudioPlayer _audioPlayer;
        
        protected override void OnInitializing()
        {
            var content = ViewModel.GetContent<AudioClip>();
            _audioPlayer.StartPlay(content.Content, content.Name);
        }

        public override void Release()
        {
            _audioPlayer.ReleaseAudio();
        }
    }
}