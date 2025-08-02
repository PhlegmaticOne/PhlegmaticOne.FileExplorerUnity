using PhlegmaticOne.FileExplorer.Features.Closing.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Entities
{
    internal sealed class ComponentSelectionButtons : MonoBehaviour
    {
        [SerializeField] private ComponentToggle _selectDeselectAllToggle;
        [SerializeField] private ComponentButton _acceptButton;
        
        private SelectionViewModel _viewModel;
        private ClosingViewModel _closingViewModel;

        public void Bind(SelectionViewModel selectionViewModel, ClosingViewModel closingViewModel)
        {
            _closingViewModel = closingViewModel;
            _viewModel = selectionViewModel;
            
            _viewModel.IsAcceptSelection.ValueChanged += UpdateIsAcceptSelection;
            _selectDeselectAllToggle.Bind(_viewModel.IsAllSelected, _viewModel.SelectDeselectCommand);
            _acceptButton.Bind(_closingViewModel.CloseCommand);
            UpdateIsAcceptSelection(_viewModel.IsAcceptSelection);
        }

        public void Release()
        {
            _selectDeselectAllToggle.Release();
            _acceptButton.Release();
            _viewModel.IsAcceptSelection.ValueChanged -= UpdateIsAcceptSelection;
            _closingViewModel = null;
            _viewModel = null;
        }

        private void UpdateIsAcceptSelection(bool isAccept)
        {
            _acceptButton.gameObject.SetActive(isAccept);
            _selectDeselectAllToggle.gameObject.SetActive(!isAccept);
        }
    }
}