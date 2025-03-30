using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Searching.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Actions;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Listeners;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Entities
{
    internal sealed class SelectionViewModel : ViewModel, ITabEntriesAddedHandler, IViewModelDisposable
    {
        private readonly ActionsViewModel _actionsViewModel;
        private readonly ISelectionActionsProvider _actionsProvider;
        private readonly TabViewModel _tabViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly List<FileEntryViewModel> _selection;

        public SelectionViewModel(
            ActionsViewModel actionsViewModel, 
            ISelectionActionsProvider actionsProvider,
            TabViewModel tabViewModel,
            SearchViewModel searchViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _actionsProvider = actionsProvider;
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
            _selection = new List<FileEntryViewModel>();

            IsAllSelected = new ReactiveProperty<bool>(false);
            IsSelectionActive = new ReactiveProperty<bool>(false);
            SelectedEntriesCount = new ReactiveProperty<FileEntriesCounter>(FileEntriesCounter.Zero);
            ActionsCommand = new CommandDelegate<ActionTargetViewPosition>(ShowSelectionActions);
            ClearSelectionCommand = new CommandDelegateEmpty(() => Clear());
            SelectDeselectCommand = new CommandDelegate<bool>(SelectDeselectAll);
        }

        public ICommand ActionsCommand { get; }
        public ICommand ClearSelectionCommand { get; }
        public ICommand SelectDeselectCommand { get; }
        public ReactiveProperty<bool> IsSelectionActive { get; }
        public ReactiveProperty<bool> IsAllSelected { get; }
        public ReactiveProperty<FileEntriesCounter> SelectedEntriesCount { get; }

        private void ShowSelectionActions(ActionTargetViewPosition position)
        {
            var actionViewPosition = position.ToActionViewPositionData(ActionViewAlignment.DockToTargetBottom);
            var actions = _actionsProvider.GetActions(this);
            _actionsViewModel.ShowActions(actions, actionViewPosition);
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
            UpdateIsSelectionActive(_selection.Count >= 1);
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
            UpdateIsSelectionActive(true);
        }

        public void Clear(bool isDisableSelection = true)
        {
            foreach (var fileEntry in _selection)
            {
                fileEntry.IsSelected.SetValueNotify(false);
            }
            
            _selection.Clear();
            IsAllSelected.SetValueNotify(false);
            UpdateIsSelectionActive(!isDisableSelection);
            SelectedEntriesCount.SetValueNotify(FileEntriesCounter.Zero);
        }

        public void HandleEntriesAdded(IEnumerable<FileEntryViewModel> fileEntries)
        {
            IsAllSelected.SetValueNotify(false);
        }
        
        private void SelectDeselectAll(bool isSelectAll)
        {
            if (!isSelectAll)
            {
                Clear(isDisableSelection: false);
            }
            else
            {
                SelectAll();
            }
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

        private void UpdateIsSelectionActive(bool isActive)
        {
            IsSelectionActive.SetValueNotify(isActive);
            _searchViewModel.SetActive(!isActive);
        }

        private void UpdateIsAllSelected()
        {
            var activeCount = _tabViewModel.FileEntries.Count(x => x.IsActive);
            var isAllSelected = activeCount != 0 && _selection.Count == activeCount;
            IsAllSelected.SetValueNotify(isAllSelected);
        }

        public void Dispose()
        {
            Clear();
        }
    }
}