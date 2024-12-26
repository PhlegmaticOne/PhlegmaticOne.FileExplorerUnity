using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal sealed class ActionViewPositionCalculator : IActionViewPositionCalculator
    {
        private const float AddOffsetX = 3;
        
        private readonly ActionViewScrollRect _scrollRect;

        private float ScrollY => _scrollRect.ScrollRect.anchoredPosition.y;
        
        public ActionViewPositionCalculator(ActionViewScrollRect scrollRect)
        {
            _scrollRect = scrollRect;
        }
        
        // Target pivot is center-center
        // Dropdown pivot is left-up corner
        public Vector2 Calculate(ActionViewPositionData targetPosition, Vector2 viewSize)
        {
            return new Vector2(
                CalculateViewX(targetPosition, viewSize),
                CalculateViewY(targetPosition, viewSize));
        }
        
        private static float CalculateViewX(ActionViewPositionData position, Vector2 size)
        {
            var targetCenter = position.TargetCenterAnchoredPosition;
            var targetSize = position.TargetSize;

            return targetCenter.x <= Screen.width / 2f
                ? targetCenter.x + (targetSize.x / 2 + AddOffsetX)
                : targetCenter.x - (size.x + targetSize.x / 2 + AddOffsetX);
        }

        private float CalculateViewY(ActionViewPositionData position, Vector2 size)
        {
            var targetCenter = position.TargetCenterAnchoredPosition;
            var targetSize = position.TargetSize;
            var targetCenterY = position.TargetOffsetFromTop + Mathf.Abs(targetCenter.y) - ScrollY;
            
            var dockedTargetCenterY = position.Alignment switch
            {
                ActionViewAlignment.DockToTargetTop => targetCenterY - targetSize.y / 2,
                ActionViewAlignment.DockToTargetCenter => targetCenterY - size.y / 2,
                ActionViewAlignment.DockToTargetBottom => targetCenterY + targetSize.y / 2,
                _ => targetCenterY - size.y / 2
            };

            var clampedTargetCenterY = Mathf.Clamp(
                dockedTargetCenterY, position.TargetOffsetFromTop, Screen.height - targetSize.y);
            
            return clampedTargetCenterY * -1f;
        }
    }
}