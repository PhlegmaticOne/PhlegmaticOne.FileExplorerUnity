using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class RectTransformExtensions
    {
        public static Rect GetWorldCornersRectNonAlloc(this RectTransform rectTransform, Span<Vector3> fourCornersSpan)
        {
            GetWorldCornersNonAlloc(rectTransform, fourCornersSpan);

            var sizeX = Mathf.Abs(fourCornersSpan[0].x - fourCornersSpan[2].x);
            var sizeY = Mathf.Abs(fourCornersSpan[0].y - fourCornersSpan[2].y);

            return new Rect(fourCornersSpan[0], new Vector2(sizeX, sizeY));
        }
        
        public static void GetWorldCornersNonAlloc(this RectTransform rectTransform, Span<Vector3> fourCornersSpan)
        {
            if (fourCornersSpan.Length >= 4)
            {
                GetLocalCornersNonAlloc(rectTransform, fourCornersSpan);
                var localToWorldMatrix = rectTransform.localToWorldMatrix;

                for (var index = 0; index < 4; ++index)
                {
                    fourCornersSpan[index] = localToWorldMatrix.MultiplyPoint(fourCornersSpan[index]);
                }
            }
        }
        
        public static void GetLocalCornersNonAlloc(this RectTransform rectTransform, Span<Vector3> fourCornersSpan)
        {
            if (fourCornersSpan.Length >= 4)
            {
                var rect = rectTransform.rect;
                var x = rect.x;
                var y = rect.y;
                var xMax = rect.xMax;
                var yMax = rect.yMax;
                fourCornersSpan[0] = new Vector3(x, y, 0.0f);
                fourCornersSpan[1] = new Vector3(x, yMax, 0.0f);
                fourCornersSpan[2] = new Vector3(xMax, yMax, 0.0f);
                fourCornersSpan[3] = new Vector3(xMax, y, 0.0f);
            }
        }
    }
}