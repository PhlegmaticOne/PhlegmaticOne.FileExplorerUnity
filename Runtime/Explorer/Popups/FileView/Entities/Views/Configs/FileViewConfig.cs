using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    [Serializable]
    internal sealed class FileViewConfig
    {
        [SerializeField] private float _minSliderValue;
        [SerializeField] private float _maxSliderValue;
        [SerializeField] private float _initialSliderValue;
        [SerializeField] private bool _useIntegerSliderValues;
        [SerializeField] private bool _hasResizeSlider;
        [SerializeField] private bool _lockScrolling;
        
        public bool HasResizeSlider => _hasResizeSlider;
        public float MinSliderValue => _minSliderValue;
        public float MaxSliderValue => _maxSliderValue;
        public bool UseIntegerSliderValues => _useIntegerSliderValues;
        public float InitialSliderValue => _initialSliderValue;
        public bool LockScrolling => _lockScrolling;
    }
}