using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Selection.ViewModels
{
    internal sealed class SelectionViewModel
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly List<FileEntryViewModel> _selection;

        public SelectionViewModel(FileEntryActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _selection = new List<FileEntryViewModel>();
            
            IsSelectionActive = new ReactiveProperty<bool>(false);
            Position = new FileEntryPosition();
            SelectedEntriesCount = new ReactiveProperty<FileEntriesCounter>(FileEntriesCounter.Zero);
        }

        public ReactiveProperty<bool> IsSelectionActive { get; }
        public ReactiveProperty<FileEntriesCounter> SelectedEntriesCount { get; }
        public FileEntryPosition Position { get; }

        public void OnSelectionActionsClick()
        {
            var position = Position.ToActionViewPositionData(FileActionViewAlignment.DockToTargetBottom);
        }

        public void UpdateSelection(FileEntryViewModel viewModel)
        {
            var newIsSelected = !viewModel.IsSelected;
            viewModel.IsSelected.SetValueNotify(newIsSelected);
            UpdateSelectionCollection(viewModel, newIsSelected);
            UpdateSelectionCount(viewModel, newIsSelected);
            UpdateIsSelectionActive();
        }

        public void ClearSelection()
        {
            foreach (var fileEntry in _selection)
            {
                fileEntry.IsSelected.SetValueNotify(false);
            }
            
            _selection.Clear();
            UpdateIsSelectionActive();
            SelectedEntriesCount.SetValueNotify(FileEntriesCounter.Zero);
        }

        private void UpdateSelectionCount(FileEntryViewModel viewModel, bool newIsSelected)
        {
            var count = SelectedEntriesCount.Value;
            var delta = newIsSelected ? 1 : -1;
            count.AddDelta(delta, viewModel.EntryType);
            SelectedEntriesCount.SetValueNotify(count);
        }
        
        private void UpdateSelectionCollection(FileEntryViewModel viewModel, bool newIsSelected)
        {
            if (newIsSelected)
            {
                _selection.Add(viewModel);
            }
            else
            {
                _selection.Remove(viewModel);
            }
        }

        private void UpdateIsSelectionActive()
        {
            IsSelectionActive.SetValueNotify(_selection.Count >= 1);
        }
    }
}