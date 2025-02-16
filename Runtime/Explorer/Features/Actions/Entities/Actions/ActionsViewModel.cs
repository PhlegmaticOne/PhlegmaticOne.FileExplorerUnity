using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions
{
    internal sealed class ActionsViewModel : ViewModel
    {
        private readonly IActionViewPositionCalculator _positionCalculator;
        
        private ActionViewPositionData _position;
        private FileEntryViewModel _fileEntry;
        
        public ActionsViewModel(IActionViewPositionCalculator positionCalculator)
        {
            _positionCalculator = positionCalculator;
            
            IsActive = new ReactiveProperty<bool>();
            Actions = new ReactiveCollection<ActionViewModel>();
            Position = new ReactiveProperty<Vector3>();
        }

        public event System.Action Activated;
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveCollection<ActionViewModel> Actions { get; }

        public void ShowActions(IEnumerable<ActionViewModel> actions, ActionViewPositionData position)
        {
            _position = position;
            Actions.Clear();
            Actions.AddRange(actions);
            IsActive.SetValueNotify(true);
            Activated?.Invoke();
        }

        public void SetActiveEntry(FileEntryViewModel fileEntry)
        {
            _fileEntry = fileEntry;
            _fileEntry.IsSelected.SetValueNotify(true);
        }

        public void RaiseUpdatePosition(Vector2 viewSize)
        {
            var dropdownPosition = _positionCalculator.Calculate(_position, viewSize);
            Position.SetValueNotify(dropdownPosition);
        }

        public void Deactivate()
        {
            Actions.Clear();
            IsActive.SetValueNotify(false);
            _fileEntry?.IsSelected.SetValueNotify(false);
            _position = null;
            _fileEntry = null;
        }
    }
}