using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal abstract class FileViewBase : View
    {
        [SerializeField] private float _minSliderValue;
        [SerializeField] private float _maxSliderValue;
        [SerializeField] private float _initialSliderValue;
        [SerializeField] private bool _useIntegerSliderValues;
        [SerializeField] private bool _hasResizeSlider;
        [SerializeField] private bool _lockScrolling;
        
        protected FileViewViewModel ViewModel;

        [ViewInject]
        public void Construct(FileViewViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        
        public bool HasResizeSlider => _hasResizeSlider;
        public float MinSliderValue => _minSliderValue;
        public float MaxSliderValue => _maxSliderValue;
        public bool UseIntegerSliderValues => _useIntegerSliderValues;
        public float InitialSliderValue => _initialSliderValue;
        public bool LockScrolling => _lockScrolling;

        public virtual void Resize(float size) { }
    }
}