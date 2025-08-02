using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal sealed class ActionDropdownViewPosition
    {
        public ActionDropdownViewPosition(
            Vector2 targetCenterAnchoredPosition, 
            Vector2 targetSize, 
            float targetOffsetFromTop, 
            ActionViewAlignment alignment)
        {
            TargetCenterAnchoredPosition = targetCenterAnchoredPosition;
            TargetSize = targetSize;
            TargetOffsetFromTop = targetOffsetFromTop;
            Alignment = alignment;
        }

        public Vector2 TargetCenterAnchoredPosition { get; }
        public Vector2 TargetSize { get; }
        public float TargetOffsetFromTop { get; }
        public ActionViewAlignment Alignment { get; }
    }
}