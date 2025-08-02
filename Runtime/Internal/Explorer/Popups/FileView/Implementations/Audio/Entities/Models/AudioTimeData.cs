using System;

namespace PhlegmaticOne.FileExplorer.Popups.FileView.Models
{
    internal sealed class AudioTimeData : IEquatable<AudioTimeData>
    {
        public AudioTimeData(float duration)
        {
            Duration = duration;
        }

        public float CurrentTime { get; private set; }
        public float Duration { get; }

        public void SetTime(float time)
        {
            CurrentTime = time;
        }
        
        public bool Equals(AudioTimeData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CurrentTime.Equals(other.CurrentTime) && Duration.Equals(other.Duration);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is AudioTimeData other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CurrentTime, Duration);
        }
    }
}