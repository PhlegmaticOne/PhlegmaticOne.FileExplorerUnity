using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.FileView.Components
{
    internal sealed class ComponentFileViewScaleSlider : View
    {
        [SerializeField] private Slider _slider;
        
        private FileViewBase _fileView;

        [ViewInject]
        public void Construct(FileViewBase fileView)
        {
            _fileView = fileView;
        }

        protected override void OnInitializing()
        {
            var config = _fileView.ViewConfig;
            _slider.minValue = config.MinSliderValue;
            _slider.maxValue = config.MaxSliderValue;
            _slider.wholeNumbers = config.UseIntegerSliderValues;
            _slider.value = config.InitialSliderValue;
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