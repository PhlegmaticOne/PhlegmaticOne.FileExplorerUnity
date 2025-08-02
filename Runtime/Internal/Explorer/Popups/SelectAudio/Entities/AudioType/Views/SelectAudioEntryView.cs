using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal sealed class SelectAudioEntryView : View
    {
        [SerializeField] private ComponentText _extensionText;
        [SerializeField] private ComponentButton _button;
        
        private SelectAudioEntryViewModel _viewModel;

        [ViewInject]
        public void Construct(SelectAudioEntryViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        protected override void OnInitializing()
        {
            _extensionText.Bind(_viewModel.Extension);
            _button.Bind(_viewModel.SelectCommand);
        }

        public override void Release()
        {
            _extensionText.Release();
            _button.Release();
            _viewModel = null;
        }
    }
}