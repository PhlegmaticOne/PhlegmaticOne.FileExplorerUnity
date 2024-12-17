using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal class FileActionViewPositionData
    {
        public FileActionViewPositionData(Vector2 targetCenterAnchoredPosition, Vector2 targetSize, float targetOffsetFromTop, FileActionViewAlignment alignment)
        {
            TargetCenterAnchoredPosition = targetCenterAnchoredPosition;
            TargetSize = targetSize;
            TargetOffsetFromTop = targetOffsetFromTop;
            Alignment = alignment;
        }

        public Vector2 TargetCenterAnchoredPosition { get; }
        public Vector2 TargetSize { get; }
        public float TargetOffsetFromTop { get; }
        public FileActionViewAlignment Alignment { get; }
    }
}