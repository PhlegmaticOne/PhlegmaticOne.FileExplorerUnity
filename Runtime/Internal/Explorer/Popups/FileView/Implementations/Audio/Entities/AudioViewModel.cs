using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Popups.FileView.Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class AudioViewModel
    {
        private readonly AudioSource _audioSource;
        private readonly AudioClip _audioClip;

        private float _lastVolume;
        private bool _isReleased;
        
        public AudioViewModel(AudioSource audioSource, AudioClip audioClip, string name)
        {
            _audioSource = audioSource;
            _audioClip = audioClip;
            _lastVolume = _audioSource.volume;

            Name = new ReactiveProperty<string>(name);
            Volume = new ReactiveProperty<float>(_lastVolume);
            IsMuted = new ReactiveProperty<bool>(GetIsMuted());
            Time = new ReactiveProperty<AudioTimeData>(new AudioTimeData(audioClip.length));
            PlayPauseCommand = new CommandDelegate<bool>(SetIsPlaying);
            MuteUnmuteCommand = new CommandDelegate<bool>(SetMuted);
            RealTime = new ReactiveProperty<float>(0);
            IsPlaying = new ReactiveProperty<bool>(false);
            SetTimeCommand = new CommandDelegate<float>(SetTime);
            SetVolumeCommand = new CommandDelegate<float>(SetVolume);
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<bool> IsMuted { get; }
        public ReactiveProperty<float> Volume { get; }
        public ReactiveProperty<bool> IsPlaying { get; }
        public ReactiveProperty<float> RealTime { get; }
        public ReactiveProperty<AudioTimeData> Time { get; }
        public ICommand PlayPauseCommand { get; }
        public ICommand MuteUnmuteCommand { get; }
        public ICommand SetTimeCommand { get; }
        public ICommand SetVolumeCommand { get; }

        public void Play()
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            IsPlaying.SetValueNotify(true);
            SetTime(0.01f);
            LoopUpdateTime().Forget();
        }

        public float GetDuration()
        {
            return Time.Value.Duration;
        }

        public void Release()
        {
            _isReleased = true;
            IsPlaying.SetValueNotify(false);
            _audioSource.Stop();
            _audioSource.clip = null;
            Object.Destroy(_audioClip);
        }

        private async Task LoopUpdateTime()
        {
            while (!_isReleased && ClipIsPlaying())
            {
                var realTime = _audioSource.time;
                var realTimeSpan = TimeSpan.FromSeconds(realTime);

                if (realTimeSpan.TotalSeconds - Time.Value.CurrentTime >= 1)
                {
                    SetTimeProperty((float)realTimeSpan.TotalSeconds);
                }
                
                RealTime.SetValueNotify(realTime);
                
                await Task.Yield();
            }
            
            ResetAudio();
        }

        private void ResetAudio()
        {
            IsPlaying.SetValueNotify(false);
            RealTime.SetValueNotify(0);
            SetTimeProperty(0);
        }

        private void SetIsPlaying(bool isPlaying)
        {
            if (!ClipIsPlaying())
            {
                if (isPlaying)
                {
                    Play();
                }
                
                return;
            }
            
            if (isPlaying)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Pause();
            }
        }

        private void SetTime(float time)
        {
            var timeClamped = Mathf.Clamp(time, 0.01f, _audioClip.length);
            _audioSource.time = timeClamped;
            SetTimeProperty(timeClamped);
        }

        private void SetVolume(float volume)
        {
            _audioSource.volume = Mathf.Clamp01(volume);
            IsMuted.SetValueNotify(GetIsMuted());
        }

        private void SetMuted(bool isMuted)
        {
            if (isMuted)
            {
                _lastVolume = Volume;
                _audioSource.volume = 0;
                Volume.SetValueNotify(0);
            }
            else
            {
                _audioSource.volume = _lastVolume;
                Volume.SetValueNotify(_lastVolume);
            }
        }

        private void SetTimeProperty(float time)
        {
            Time.Value.SetTime(time);
            Time.Raise();
        }

        private bool ClipIsPlaying()
        {
            return _audioSource.isPlaying || !Mathf.Approximately(_audioSource.time, 0);
        }

        private bool GetIsMuted()
        {
            return Mathf.Approximately(0, _audioSource.volume);
        }
    }
}