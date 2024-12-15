using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.FileView.Views
{
    internal abstract class FileViewBase : MonoBehaviour
    {
        [SerializeField] private float _minSliderValue;
        [SerializeField] private float _maxSliderValue;
        [SerializeField] private float _initialSliderValue;
        [SerializeField] private bool _useIntegerSliderValues;

        public float MinSliderValue => _minSliderValue;
        public float MaxSliderValue => _maxSliderValue;
        public bool UseIntegerSliderValues => _useIntegerSliderValues;
        public float InitialSliderValue => _initialSliderValue;
        
        public abstract FileViewType ViewType { get; }
        public abstract bool Setup(FileViewViewModel viewModel, TextMeshProUGUI errorText);
        public abstract void Resize(float size);
        public abstract void Release();
    }
}