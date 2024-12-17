using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.Services;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Selection.ViewModels
{
    internal sealed class SelectionViewModel
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly ISelectionActionsProvider _actionsProvider;
        private readonly TabViewModel _tabViewModel;
        private readonly List<FileEntryViewModel> _selection;

        public SelectionViewModel(
            FileEntryActionsViewModel actionsViewModel, 
            ISelectionActionsProvider actionsProvider,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _actionsProvider = actionsProvider;
            _tabViewModel = tabViewModel;
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
            var actions = _actionsProvider.GetActions(this);
            _actionsViewModel.ShowActions(actions, position);
        }

        public bool TryGetSingleSelection(out FileEntryViewModel fileEntry)
        {
            fileEntry = _selection.FirstOrDefault();
            return _selection.Count == 1;
        }

        public bool IsAnySelected()
        {
            return _selection.Count >= 1;
        }

        public bool IsAllSelected()
        {
            return _selection.Count == _tabViewModel.FileEntries.Count;
        }

        public IReadOnlyList<FileEntryViewModel> GetSelection()
        {
            return _selection;
        }

        public void UpdateSelection(FileEntryViewModel viewModel)
        {
            var newIsSelected = !viewModel.IsSelected;
            viewModel.IsSelected.SetValueNotify(newIsSelected);
            UpdateSelectionCollection(viewModel, newIsSelected);
            UpdateSelectionCount(viewModel, newIsSelected, notify: true);
            UpdateIsSelectionActive();
        }

        public void SelectAll()
        {
            foreach (var fileEntry in _tabViewModel.FileEntries)
            {
                if (!fileEntry.IsSelected)
                {
                    fileEntry.IsSelected.SetValueNotify(true);
                    UpdateSelectionCount(fileEntry, newIsSelected: true, notify: false);
                    _selection.Add(fileEntry);
                }
            }
            
            SelectedEntriesCount.Raise();
            IsSelectionActive.SetValueNotify(true);
        }

        public void ClearSelection()
        {
            foreach (var fileEntry in _selection)
            {
                fileEntry.IsSelected.SetValueNotify(false);
            }
            
            _selection.Clear();
            IsSelectionActive.SetValueNotify(false);
            SelectedEntriesCount.SetValueNotify(FileEntriesCounter.Zero);
        }

        private void UpdateSelectionCount(FileEntryViewModel viewModel, bool newIsSelected, bool notify)
        {
            var count = SelectedEntriesCount.Value;
            var delta = newIsSelected ? 1 : -1;
            count.AddDelta(delta, viewModel.EntryType);
            SelectedEntriesCount.SetValue(count, notify);
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