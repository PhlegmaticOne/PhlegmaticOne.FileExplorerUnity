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

        public float ModifyOffset(float offset, float size)
        {
            return Alignment switch
            {
                FileActionViewAlignment.DockToTargetTop => offset - size / 2,
                FileActionViewAlignment.DockToTargetCenter => offset - size / 2,
                FileActionViewAlignment.DockToTargetBottom => offset + size / 2,
                _ => offset
            };
        }
    }
}