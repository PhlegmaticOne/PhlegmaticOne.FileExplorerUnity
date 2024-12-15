using PhlegmaticOne.FileExplorer.Core.Navigation.Services;
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

        private PostfixTextFormatter _formatter;
        
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

        private void Show()
        {
            _formatter = new PostfixTextFormatter(_loadingTextValue, '.');
            enabled = true;
            _currentTime = 0;
            _loadingText.gameObject.SetActive(true);
            UpdatePointsCount(1);
        }

        private void Hide()
        {
            _loadingText.gameObject.SetActive(false);
            enabled = false;
            _formatter = null;
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
            _loadingText.text = _formatter.GetFormattedText(pointsCount);
        }
    }
}