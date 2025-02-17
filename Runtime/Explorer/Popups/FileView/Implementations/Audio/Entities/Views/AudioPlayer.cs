using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Slider _timelineSlider;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private ToggleOnOff _playPauseToggle;
        [SerializeField] private ToggleOnOff _soundToggle;
        [SerializeField] private AudioTimeView _timeText;
        [SerializeField] private TextMeshProUGUI _fileNameText;

        private AudioViewModel _viewModel;

        public void StartPlay(AudioClip clip, string displayName)
        {
            _viewModel = new AudioViewModel(_audioSource, clip, displayName);
            Subscribe();
            SetupView();
            _viewModel.Play();
        }

        public void ReleaseAudio()
        {
            Unsubscribe();
            _viewModel.Release();
            _viewModel = null;
        }

        private void SetupView()
        {
            _fileNameText.text = _viewModel.Name;
            
            _soundToggle.SetIsOnWithoutNotify(!_viewModel.IsMuted);

            _playPauseToggle.SetIsOnWithoutNotify(true);

            _timelineSlider.minValue = 0;
            _timelineSlider.maxValue = _viewModel.Duration;

            _volumeSlider.minValue = 0;
            _volumeSlider.maxValue = 1;
            _volumeSlider.value = _viewModel.Volume;
        }

        private void Subscribe()
        {
            _soundToggle.AddListener(HandleSoundToggleChanged);
            _playPauseToggle.AddListener(HandlePlayPauseChanged);
            _timelineSlider.onValueChanged.AddListener(SetTime);
            _volumeSlider.onValueChanged.AddListener(SetVolume);
            
            _viewModel.Time.ValueChanged += UpdateTimeView;
            _viewModel.Volume.ValueChanged += UpdateVolumeView;
            _viewModel.IsMuted.ValueChanged += UpdateIsMutedView;
            _viewModel.ClipTick += UpdateTimeSlider;
        }

        private void Unsubscribe()
        {
            _soundToggle.RemoveListener(HandleSoundToggleChanged);
            _playPauseToggle.RemoveListener(HandlePlayPauseChanged);
            _timelineSlider.onValueChanged.RemoveListener(SetTime);
            _volumeSlider.onValueChanged.RemoveListener(SetVolume);
            
            _viewModel.Time.ValueChanged -= UpdateTimeView;
            _viewModel.Volume.ValueChanged -= UpdateVolumeView;
            _viewModel.IsMuted.ValueChanged -= UpdateIsMutedView;
            _viewModel.ClipTick -= UpdateTimeSlider;
        }

        private void SetTime(float time)
        {
            _viewModel.SetTime(time);
        }

        private void SetVolume(float volume)
        {
            _viewModel.SetVolume(volume);
        }

        private void HandlePlayPauseChanged(bool isPlay)
        {
            _viewModel.SetIsPlaying(isPlay);
        }

        private void UpdateTimeSlider()
        {
            _timelineSlider.SetValueWithoutNotify(_viewModel.GetRealTime());
        }

        private void HandleSoundToggleChanged(bool isActive)
        {
            _viewModel.SetMuted(!isActive);
        }
        
        private void UpdateIsMutedView(bool isMuted)
        {
            _soundToggle.SetIsOnWithoutNotify(!isMuted);
        }

        private void UpdateVolumeView(float volume)
        {
            _volumeSlider.SetValueWithoutNotify(volume);
        }

        private void UpdateTimeView(float time)
        {
            _timeText.UpdateTime(time, _viewModel.Duration);
        }
    }
}