using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Audio
{
    internal sealed class AudioPlayerController
    {
        private readonly AudioSource _audioSource;
        private readonly AudioClip _audioClip;

        public AudioPlayerController(AudioSource audioSource, AudioClip audioClip)
        {
            _audioSource = audioSource;
            _audioClip = audioClip;
        }
        
        public bool IsPlaying { get; private set; }
        
        public void Play()
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            IsPlaying = true;
        }

        public float GetClipDuration()
        {
            return _audioClip.length;
        }

        public bool IsMuted()
        {
            return _audioSource.mute;
        }
        
        public void Mute()
        {
            _audioSource.mute = true;
        }
        
        public void Unmute()
        {
            _audioSource.mute = false;
        }

        public void Pause()
        {
            _audioSource.Pause();
            IsPlaying = false;
        }

        public void SetVolume(float volume)
        {
            _audioSource.volume = Mathf.Clamp01(volume);
        }

        public float GetVolume()
        {
            return _audioSource.volume;
        }

        public void SetTime(float time)
        {
            _audioSource.time = Mathf.Clamp(time, 0, _audioClip.length);
        }

        public float GetTime()
        {
            return _audioSource.time;
        }

        public void Release()
        {
            IsPlaying = false;
            _audioSource.Stop();
            Object.Destroy(_audioClip);
        }
    }
}