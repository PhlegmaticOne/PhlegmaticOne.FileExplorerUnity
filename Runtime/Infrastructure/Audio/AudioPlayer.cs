using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Audio.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Audio
{
    internal sealed class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Slider _timelineSlider;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private ToggleOnOff _playPauseToggle;
        [SerializeField] private ToggleOnOff _soundToggle;
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _fileNameText;

        private AudioPlayerController _audioPlayerController;

        public void StartPlay(AudioClip clip, string displayName)
        {
            _audioPlayerController = new AudioPlayerController(_audioSource, clip);
            Subscribe();
            SetupView();
            _fileNameText.text = displayName;
            _audioPlayerController.Play();
        }

        private void Update()
        {
            if (_audioPlayerController is not null)
            {
                var time = _audioPlayerController.GetTime();
                var timeText = TimeSpan.FromSeconds(time).ToString("mm\\:ss") + "/" + 
                               TimeSpan.FromSeconds(_audioPlayerController.GetClipDuration()).ToString("mm\\:ss");
                _timeText.text = timeText;
                _timelineSlider.SetValueWithoutNotify(time);
            }
        }

        public void ReleaseAudio()
        {
            Unsubscribe();
            _audioPlayerController.Release();
            _audioPlayerController = null;
        }

        private void SetupView()
        {
            _soundToggle.SetIsOnNotify(!_audioPlayerController.IsMuted());

            _playPauseToggle.SetIsOnNotify(true);

            _timelineSlider.minValue = 0;
            _timelineSlider.maxValue = _audioPlayerController.GetClipDuration();

            _volumeSlider.minValue = 0;
            _volumeSlider.maxValue = 1;
            _volumeSlider.value = _audioPlayerController.GetVolume();
        }

        private void Subscribe()
        {
            _soundToggle.AddListener(HandleSoundToggleChanged);
            _playPauseToggle.AddListener(HandlePlayPauseChanged);
            _timelineSlider.onValueChanged.AddListener(RewindClip);
            _volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void Unsubscribe()
        {
            _soundToggle.RemoveListener(HandleSoundToggleChanged);
            _playPauseToggle.RemoveListener(HandlePlayPauseChanged);
            _timelineSlider.onValueChanged.RemoveListener(RewindClip);
            _volumeSlider.onValueChanged.RemoveListener(SetVolume);
        }

        private void RewindClip(float time)
        {
            _audioPlayerController.SetTime(time);
        }
        
        private void SetVolume(float volume)
        {
            _audioPlayerController.SetVolume(volume);
            _soundToggle.SetIsOnWithoutNotify(!_audioPlayerController.IsMuted());
        }

        private void HandlePlayPauseChanged(bool isPlay)
        {
            if (isPlay)
            {
                _audioPlayerController.Play();
            }
            else
            {
                _audioPlayerController.Pause();
            }
        }
        
        private void HandleSoundToggleChanged(bool isActive)
        {
            if (isActive)
            {
                _volumeSlider.SetValueWithoutNotify(_audioPlayerController.GetVolume());
                _soundToggle.SetIsOnWithoutNotify(!_audioPlayerController.IsMuted());
            }
            else
            {
                _volumeSlider.SetValueWithoutNotify(0);
                _soundToggle.SetIsOnWithoutNotify(!_audioPlayerController.IsMuted());
            }
        }
    }
}