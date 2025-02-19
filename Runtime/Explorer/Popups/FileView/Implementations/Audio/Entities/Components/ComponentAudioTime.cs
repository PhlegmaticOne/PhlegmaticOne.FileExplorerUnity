using System;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Popups.FileView.Models;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class ComponentAudioTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private string _timeFormat = "mm\\:ss";
        [SerializeField] private string _format = "{0}/{1}";
        
        private ReactiveProperty<AudioTimeData> _property;

        public void Bind(ReactiveProperty<AudioTimeData> property)
        {
            _property = property;
            _property.ValueChanged += UpdateTime;
        }

        public void Release()
        {
            _property.ValueChanged -= UpdateTime;
            _property = null;
        }

        private void UpdateTime(AudioTimeData time)
        {
            var timeText = string.Format(_format, GetTimeView(time.CurrentTime), GetTimeView(time.Duration));
            _timeText.text = timeText;
        }

        private string GetTimeView(float time)
        {
            return TimeSpan.FromSeconds(time).ToString(_timeFormat);
        }
    }
}