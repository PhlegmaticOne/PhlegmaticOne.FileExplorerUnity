using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries
{
    internal sealed class FileEntryPosition
    {
        public Vector2 CenterAnchoredPosition { get; private set; }
        public Vector2 Size { get; private set; }
        public float OffsetTop { get; private set; }
        
        public void Update(Vector2 worldPosition, Vector2 size, float offsetTop)
        {
            Size = size;
            CenterAnchoredPosition = worldPosition;
            OffsetTop = offsetTop;
        }

        public FileActionViewPositionData ToActionViewPositionData(FileActionViewAlignment alignment)
        {
            return new FileActionViewPositionData(CenterAnchoredPosition, Size, OffsetTop, alignment);
        }
    }
}