using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView.Components
{
    internal sealed class ComponentFileViewScaleSlider : View
    {
        [SerializeField] private Slider _slider;
        
        private FileViewBase _fileView;
        
        protected override void OnInitializing() { }

        public void Bind(FileViewBase fileView)
        {
            _fileView = fileView;
            
            _slider.gameObject.SetActive(fileView.HasResizeSlider);
            _slider.minValue = fileView.MinSliderValue;
            _slider.maxValue = fileView.MaxSliderValue;
            _slider.wholeNumbers = fileView.UseIntegerSliderValues;
            _slider.value = fileView.InitialSliderValue;
            _slider.onValueChanged.AddListener(ResizeFileView);
        }

        public override void Release()
        {
            _slider.onValueChanged.RemoveListener(ResizeFileView);
            _fileView = null;
        }

        private void ResizeFileView(float size)
        {
            _fileView.Resize(size);
        }
    }
}