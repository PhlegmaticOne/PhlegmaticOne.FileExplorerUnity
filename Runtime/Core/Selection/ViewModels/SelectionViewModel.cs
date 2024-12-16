using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Selection.ViewModels
{
    internal sealed class SelectionViewModel
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;

        public SelectionViewModel(FileEntryActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
            
            IsSelectionActive = new ReactiveProperty<bool>(false);
            Selection = new ReactiveCollection<FileEntryViewModel>();
            Position = new FileEntryPosition();
        }
        
        public ReactiveProperty<bool> IsSelectionActive { get; }
        public ReactiveCollection<FileEntryViewModel> Selection { get; }
        public FileEntryPosition Position { get; }

        public void OnSelectionActionsClick()
        {
            var position = Position.ToActionViewPositionData(FileActionViewAlignment.DockToTargetBottom);
        }

        public void SelectEntry(FileEntryViewModel viewModel)
        {
            Selection.Add(viewModel);
        }

        public void ClearSelection()
        {
            Selection.Clear();
            IsSelectionActive.SetValueNotify(false);
        }

        private bool IsSingleEntrySelected()
        {
            return Selection.Count == 1;
        }
    }
}