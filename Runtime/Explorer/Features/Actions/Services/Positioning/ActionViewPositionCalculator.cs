using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal sealed class ActionViewPositionCalculator : IActionViewPositionCalculator
    {
        private readonly ActionViewContainersData _containersData;

        public ActionViewPositionCalculator(ActionViewContainersData containersData)
        {
            _containersData = containersData;
        }
        
        // Target pivot is center-center
        // Dropdown pivot is left-up corner
        public Vector2 Calculate(ActionDropdownViewPosition targetPosition, Vector2 viewSize)
        {
            return new Vector2(
                CalculateViewX(targetPosition, viewSize),
                CalculateViewY(targetPosition, viewSize));
        }
        
        private float CalculateViewX(ActionDropdownViewPosition position, Vector2 size)
        {
            var targetCenter = position.TargetCenterAnchoredPosition;
            var targetSize = position.TargetSize;
            var width = _containersData.Parent.rect.width;
            var borderX = _containersData.BorderOffset.x;

            var dockedTargetCenterX = targetCenter.x <= width / 2f
                ? targetCenter.x + (targetSize.x / 2 + _containersData.AddOffsetX)
                : targetCenter.x - (size.x + targetSize.x / 2 + _containersData.AddOffsetX);

            var clampedTargetCenterX = Mathf.Clamp(
                dockedTargetCenterX, borderX, width - targetSize.x - borderX);

            return clampedTargetCenterX;
        }

        private float CalculateViewY(ActionDropdownViewPosition position, Vector2 size)
        {
            var targetCenter = position.TargetCenterAnchoredPosition;
            var targetSize = position.TargetSize;
            var topOffset = position.TargetOffsetFromTop;
            var scrollY = _containersData.ScrollRect.anchoredPosition.y;
            var targetCenterY = topOffset + Mathf.Abs(targetCenter.y) - scrollY;
            var height = _containersData.Parent.rect.height;
            var borderY = _containersData.BorderOffset.y;
            
            var dockedTargetCenterY = position.Alignment switch
            {
                ActionViewAlignment.DockToTargetTop => targetCenterY - targetSize.y / 2,
                ActionViewAlignment.DockToTargetCenter => targetCenterY - size.y / 2,
                ActionViewAlignment.DockToTargetBottom => targetCenterY + targetSize.y / 2,
                _ => targetCenterY - size.y / 2
            };

            var clampedTargetCenterY = Mathf.Clamp(
                dockedTargetCenterY, topOffset + borderY, height - targetSize.y - borderY);
            
            return clampedTargetCenterY * -1f;
        }
    }
}