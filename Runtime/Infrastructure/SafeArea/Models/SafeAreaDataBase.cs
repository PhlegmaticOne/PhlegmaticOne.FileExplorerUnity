using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Models
{
    internal abstract class SafeAreaDataBase : ISafeAreaData
    {
        private float _offsetRight;
        private float _offsetBottom;
        private float _offsetLeft;
        private float _offsetTop;
        private float _ratioX = 1;
        private float _ratioY = 1;

        public Rect SafeArea => new()
        {
            xMin = OffsetLeft, xMax = Screen.width - OffsetRight,
            yMin = OffsetBottom, yMax = Screen.height - OffsetTop
        };

        public float OffsetRight { get; protected set; }
        public float OffsetBottom { get; protected set; }
        public float OffsetLeft { get; protected set; }
        public float OffsetTop { get; protected set; }

        public void ChangeRatio(float ratioX, float ratioY)
        {
            OffsetTop = OffsetTop / _ratioY * ratioY;
            OffsetBottom = OffsetBottom / _ratioY * ratioY;
            OffsetLeft = OffsetLeft / _ratioX * ratioX;
            OffsetRight = OffsetRight / _ratioX * ratioX;

            _ratioX = ratioX;
            _ratioY = ratioY;
        }
    }
}