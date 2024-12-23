﻿using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels
{
    internal sealed class ActionsViewModel : ViewModel
    {
        private readonly IActionViewPositionCalculator _positionCalculator;
        
        private ActionViewPositionData _position;
        
        public ActionsViewModel(IActionViewPositionCalculator positionCalculator)
        {
            _positionCalculator = positionCalculator;
            
            IsActive = new ReactiveProperty<bool>();
            Actions = new ReactiveCollection<ActionViewModel>();
            Position = new ReactiveProperty<Vector3>();
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveCollection<ActionViewModel> Actions { get; }

        public void ShowActions(IEnumerable<ActionViewModel> actions, ActionViewPositionData position)
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