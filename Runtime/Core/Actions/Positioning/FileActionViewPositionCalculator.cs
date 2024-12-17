using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions.ViewModels
{
    internal sealed class FileActionViewPositionCalculator : IFileActionViewPositionCalculator
    {
        private const float AddOffsetX = 3;
        
        // Target pivot is center-center
        // Dropdown pivot is left-up corner
        public Vector2 Calculate(FileActionViewPositionData targetPosition, Vector2 viewSize)
        {
            return new Vector2(
                CalculateResultX(targetPosition, viewSize),
                CalculateResultY(targetPosition, viewSize));
        }
        
        private static float CalculateResultX(FileActionViewPositionData position, Vector2 size)
        {
            var targetCenter = position.TargetCenterAnchoredPosition;
            var targetSize = position.TargetSize;

            return targetCenter.x <= Screen.width / 2f
                ? targetCenter.x + (targetSize.x / 2 + AddOffsetX)
                : targetCenter.x - (size.x + targetSize.x / 2 + AddOffsetX);
        }

        private static float CalculateResultY(FileActionViewPositionData position, Vector2 size)
        {
            var targetCenter = position.TargetCenterAnchoredPosition;
            var targetSize = position.TargetSize;
            var targetCenterY = position.TargetOffsetFromTop + Mathf.Abs(targetCenter.y);
            
            var resultY = position.Alignment switch
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