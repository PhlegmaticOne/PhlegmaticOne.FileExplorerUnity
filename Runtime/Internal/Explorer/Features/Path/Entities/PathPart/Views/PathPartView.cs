using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart
{
    internal sealed class PathPartView : View
    {
        [SerializeField] private ComponentText _partText;
        [SerializeField] private ComponentActiveObject _nextMark;
        [SerializeField] private ComponentButton _button;
        
        private PathPartViewModel _viewModel;

        [Inject]
        public void Construct(PathPartViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override void OnInitializing()
        {
            _partText.Bind(_viewModel.Part);
            _nextMark.Bind(_viewModel.IsCurrent, inverse: true);
            _button.Bind(_viewModel.NavigateCommand);
        }

        public override void Release()
        {
            _partText.Release();
            _nextMark.Release();
            _button.Release();
        }
    }
}