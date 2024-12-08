using System;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class LoadingTextView : MonoBehaviour
    {
        [SerializeField] private string _loadingTextValue;
        [SerializeField] private int _pointsCount;
        [SerializeField] private float _changePointDuration;
        [SerializeField] private TextMeshProUGUI _loadingText;

        private float _currentTime;
        private int _previousPoints;

        public void SetActive(bool isActive)
        {
            if (isActive)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
        
        public void Show()
        {
            enabled = true;
            _currentTime = 0;
            _loadingText.gameObject.SetActive(true);
            UpdatePointsCount(1);
        }

        public void Hide()
        {
            _loadingText.gameObject.SetActive(false);
            enabled = false;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            
            var currentPoints = (int)(_currentTime / _changePointDuration) % _pointsCount + 1;

            if (_previousPoints != currentPoints)
            {
                UpdatePointsCount(currentPoints);
            }
        }

        private void UpdatePointsCount(int pointsCount)
        {
            _previousPoints = pointsCount;
            _loadingText.text = CreateLoadingText(pointsCount);
        }

        private string CreateLoadingText(int pointsCount)
        {
            return string.Create(_loadingTextValue.Length + pointsCount, _loadingTextValue, (destination, source) =>
            {
                source.AsSpan().CopyTo(destination);
                destination[_loadingTextValue.Length..].Fill('.');
            });
        }
    }
}