using System;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class AudioTimeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private string _timeFormat = "mm\\:ss";
        [SerializeField] private string _format = "{0}/{1}";

        public void UpdateTime(float time, float duration)
        {
            var timeText = string.Format(_format, GetTimeView(time), GetTimeView(duration));
            _timeText.text = timeText;
        }

        private string GetTimeView(float time)
        {
            return TimeSpan.FromSeconds(time).ToString(_timeFormat);
        }
    }
}