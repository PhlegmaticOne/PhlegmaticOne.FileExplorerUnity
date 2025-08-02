using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ComponentText _fileNameText;
        [SerializeField] private ComponentSlider _timelineSlider;
        [SerializeField] private ComponentSlider _volumeSlider;
        [SerializeField] private ComponentToggleOnOff _playPauseToggle;
        [SerializeField] private ComponentToggleOnOff _soundToggle;
        [SerializeField] private ComponentAudioTime _timeText;

        private AudioViewModel _viewModel;

        public void StartPlay(AudioClip clip, string displayName)
        {
            _viewModel = new AudioViewModel(_audioSource, clip, displayName);
            
            _fileNameText.Bind(_viewModel.Name);
            _timelineSlider.Bind(_viewModel.RealTime, _viewModel.SetTimeCommand, maxValue: _viewModel.GetDuration());
            _volumeSlider.Bind(_viewModel.Volume, _viewModel.SetVolumeCommand);
            _soundToggle.Bind(_viewModel.IsMuted, _viewModel.MuteUnmuteCommand);
            _playPauseToggle.Bind(_viewModel.IsPlaying, _viewModel.PlayPauseCommand);
            _timeText.Bind(_viewModel.Time);
            
            _viewModel.Play();
        }

        public void ReleaseAudio()
        {
            _fileNameText.Release();
            _timelineSlider.Release();
            _volumeSlider.Release();
            _soundToggle.Release();
            _playPauseToggle.Release();
            _timeText.Release();
            
            _viewModel.Release();
            _viewModel = null;
        }
    }
}