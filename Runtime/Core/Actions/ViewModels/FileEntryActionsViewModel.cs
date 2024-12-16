using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal sealed class FileEntryActionsViewModel
    {
        private const float AddOffset = 3;
        
        private FileActionViewPositionData _position;
        
        public FileEntryActionsViewModel()
        {
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

        // Target pivot is center-center
        // Dropdown pivot is left-up corner
        public void RaiseUpdatePosition(Vector2 size)
        {
            var dropdownPosition = new Vector2(CalculateResultX(size), CalculateResultY(size));
            Position.SetValueNotify(dropdownPosition);
        }

        public void Deactivate()
        {
            Actions.Clear();
            IsActive.SetValueNotify(false);
            _position = null;
        }

        private float CalculateResultX(Vector2 size)
        {
            var targetCenter = _position.TargetCenterAnchoredPosition;
            var targetSize = _position.TargetSize;

            return targetCenter.x <= Screen.width / 2f
                ? targetCenter.x + (targetSize.x / 2 + AddOffset)
                : targetCenter.x - (size.x + targetSize.x / 2 + AddOffset);
        }

        private float CalculateResultY(Vector2 size)
        {
            var targetCenter = _position.TargetCenterAnchoredPosition;
            var targetSize = _position.TargetSize;
            var targetCenterY = _position.TargetOffsetFromTop + Mathf.Abs(targetCenter.y);
            
            var resultY = _position.Alignment switch
            {
                FileActionViewAlignment.DockToTargetTop => targetCenterY - targetSize.y / 2,
                FileActionViewAlignment.DockToTargetCenter => targetCenterY - size.y / 2,
                FileActionViewAlignment.DockToTargetBottom => targetCenterY + targetSize.y / 2,
                _ => targetCenterY
            };

            return resultY * -1f;
        }
    }
}