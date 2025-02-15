using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Selection.Actions;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Listeners;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Entities
{
    internal sealed class SelectionViewModel : ViewModel, ITabEntriesAddedHandler
    {
        private readonly ActionsViewModel _actionsViewModel;
        private readonly ISelectionActionsProvider _actionsProvider;
        private readonly TabViewModel _tabViewModel;
        private readonly List<FileEntryViewModel> _selection;

        public SelectionViewModel(
            ActionsViewModel actionsViewModel, 
            ISelectionActionsProvider actionsProvider,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _actionsProvider = actionsProvider;
            _tabViewModel = tabViewModel;
            _selection = new List<FileEntryViewModel>();

            IsAllSelected = new ReactiveProperty<bool>(false);
            IsSelectionActive = new ReactiveProperty<bool>(false);
            Position = new FileEntryPosition();
            SelectedEntriesCount = new ReactiveProperty<FileEntriesCounter>(FileEntriesCounter.Zero);
        }

        public ReactiveProperty<bool> IsSelectionActive { get; }
        public ReactiveProperty<bool> IsAllSelected { get; }
        public ReactiveProperty<FileEntriesCounter> SelectedEntriesCount { get; }
        public FileEntryPosition Position { get; }

        public void OnSelectionActionsClick()
        {
            var position = Position.ToActionViewPositionData(ActionViewAlignment.DockToTargetBottom);
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
            UpdateIsAllSelected();
        }

        public void SelectAll()
        {
            foreach (var fileEntry in _tabViewModel.FileEntries)
            {
                if (!fileEntry.IsSelected && fileEntry.IsActive)
                {
                    fileEntry.IsSelected.SetValueNotify(true);
                    UpdateSelectionCount(fileEntry, newIsSelected: true, notify: false);
                    _selection.Add(fileEntry);
                }
            }
            
            SelectedEntriesCount.Raise();
            IsAllSelected.SetValueNotify(true);
            IsSelectionActive.SetValueNotify(true);
        }

        public void Clear(bool isDisableSelection = true)
        {
            foreach (var fileEntry in _selection)
            {
                fileEntry.IsSelected.SetValueNotify(false);
            }
            
            _selection.Clear();
            IsAllSelected.SetValueNotify(false);
            IsSelectionActive.SetValueNotify(!isDisableSelection);
            SelectedEntriesCount.SetValueNotify(FileEntriesCounter.Zero);
        }

        public void HandleEntriesAdded(IEnumerable<FileEntryViewModel> fileEntries)
        {
            IsAllSelected.SetValueNotify(false);
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

        private void UpdateIsAllSelected()
        {
            var activeCount = _tabViewModel.FileEntries.Count(x => x.IsActive);
            var isAllSelected = activeCount != 0 && _selection.Count == activeCount;
            IsAllSelected.SetValueNotify(isAllSelected);
        }
    }
}