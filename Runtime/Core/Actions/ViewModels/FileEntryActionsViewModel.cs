using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal sealed class FileEntryActionsViewModel
    {
        private readonly IFileActionViewPositionCalculator _positionCalculator;
        
        private FileActionViewPositionData _position;
        
        public FileEntryActionsViewModel(IFileActionViewPositionCalculator positionCalculator)
        {
            _positionCalculator = positionCalculator;
            
            IsActive = new ReactiveProperty<bool>();
            Actions = new ReactiveCollection<IFileEntryAction>();
            Position = new ReactiveProperty<Vector3>();
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveCollection<IFileEntryAction> Actions { get; }

        public void ShowActions(IEnumerable<IFileEntryAction> actions, FileActionViewPositionData position)
        {
            _position = position;
            Actions.Clear();
            Actions.AddRange(actions);
            IsActive.SetValueNotify(true);
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
            _position = null;
        }
    }
}