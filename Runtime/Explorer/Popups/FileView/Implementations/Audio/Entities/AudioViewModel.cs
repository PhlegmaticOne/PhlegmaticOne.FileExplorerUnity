using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class AudioViewModel
    {
        private readonly AudioSource _audioSource;
        private readonly AudioClip _audioClip;

        private bool _isActive;
        private float _lastVolume;
        
        public AudioViewModel(AudioSource audioSource, AudioClip audioClip, string name)
        {
            _audioSource = audioSource;
            _audioClip = audioClip;

            Name = name;
            Volume = new ReactiveProperty<float>(_audioSource.volume);
            Time = new ReactiveProperty<float>(0);
            IsMuted = new ReactiveProperty<bool>(GetIsMuted());
            Duration = audioClip.length;
        }

        public event Action ClipTick;
        public string Name { get; }
        public float Duration { get; }
        public ReactiveProperty<float> Volume { get; }
        public ReactiveProperty<bool> IsMuted { get; }
        public ReactiveProperty<float> Time { get; }

        public void Play()
        {
            _isActive = true;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            LoopUpdateTime().Forget();
        }

        public void SetIsPlaying(bool isPlaying)
        {
            if (isPlaying)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Pause();
            }
        }

        public float GetRealTime()
        {
            return _audioSource.time;
        }

        public void SetTime(float time)
        {
            var timeClamped = Mathf.Clamp(time, 0, _audioClip.length);
            _audioSource.time = time;
            Time.SetValueNotify(timeClamped);
        }

        public void SetVolume(float volume)
        {
            _audioSource.volume = Mathf.Clamp01(volume);
            Volume.SetValueWithoutNotify(volume);
            IsMuted.SetValueNotify(GetIsMuted());
        }

        public void SetMuted(bool isMuted)
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
            
            IsMuted.SetValueWithoutNotify(isMuted);
        }

        public void Release()
        {
            _isActive = false;
            _audioSource.Stop();
            Object.Destroy(_audioClip);
        }

        private async Task LoopUpdateTime()
        {
            while (_isActive)
            {
                var time = TimeSpan.FromSeconds(_audioSource.time);

                if (time.TotalSeconds - Time.Value >= 1)
                {
                    Time.SetValueNotify((float)time.TotalSeconds);
                }
                
                ClipTick?.Invoke();
                
                await Task.Yield();
            }
        }

        private bool GetIsMuted()
        {
            return Mathf.Approximately(0, _audioSource.volume);
        }
    }
}