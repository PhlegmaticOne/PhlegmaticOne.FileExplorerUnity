using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.AudioSelect
{
    internal sealed class SelectAudioEntryView : View
    {
        [SerializeField] private TextMeshProUGUI _extensionText;
        [SerializeField] private Button _button;
        
        private SelectAudioEntryViewModel _viewModel;

        [ViewInject]
        public void Construct(SelectAudioEntryViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        protected override void OnInitializing()
        {
            _extensionText.text = _viewModel.Extension;
            _button.onClick.AddListener(SelectEntry);
        }

        public override void Release()
        {
            _button.onClick.RemoveListener(SelectEntry);
        }

        private void SelectEntry()
        {
            _viewModel.Select();
        }
    }
}