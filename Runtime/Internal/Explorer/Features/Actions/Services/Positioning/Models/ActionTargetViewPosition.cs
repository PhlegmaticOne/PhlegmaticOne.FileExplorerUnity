using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal sealed class ActionTargetViewPosition
    {
        public ActionTargetViewPosition(Vector2 centerAnchoredPosition, Vector2 size, float offsetTop)
        {
            CenterAnchoredPosition = centerAnchoredPosition;
            Size = size;
            OffsetTop = offsetTop;
        }

        public Vector2 CenterAnchoredPosition { get; }
        public Vector2 Size { get; }
        public float OffsetTop { get; }

        public ActionDropdownViewPosition ToActionViewPositionData(ActionViewAlignment alignment)
        {
            return new ActionDropdownViewPosition(CenterAnchoredPosition, Size, OffsetTop, alignment);
        }
    }
}