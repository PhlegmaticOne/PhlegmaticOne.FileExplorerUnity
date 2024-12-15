using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal sealed class FileEntryActionsViewModel
    {
        private const float AddOffset = 3;
        
        private FileEntryPosition _position;
        
        public FileEntryActionsViewModel()
        {
            IsActive = new ReactiveProperty<bool>();
            Actions = new ReactiveCollection<IFileEntryAction>();
            Position = new ReactiveProperty<Vector3>();
        }
        
        public ReactiveProperty<bool> IsActive { get; }
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveCollection<IFileEntryAction> Actions { get; }

        public void ShowActions(IEnumerable<IFileEntryAction> actions, FileEntryPosition position)
        {
            _position = position;
            Actions.Clear();
            Actions.AddRange(actions);
            IsActive.SetValueNotify(true);
        }

        public void RaiseUpdatePosition(Vector2 size)
        {
            var filePosition = _position.AnchoredPosition;
            filePosition.x -= FileEntryPosition.HalfScreenWidth();
            
            var offsetX = -1f * Mathf.Sign(filePosition.x) * (size.x / 2 + _position.Size.x / 2 + AddOffset);
            var offsetY = -1f * (_position.Size.y / 2); 

            var position = filePosition + new Vector2(offsetX, offsetY);
            Position.SetValueNotify(position);
        }

        public void Deactivate()
        {
            Actions.Clear();
            IsActive.SetValueNotify(false);
            _position = null;
        }
    }
}