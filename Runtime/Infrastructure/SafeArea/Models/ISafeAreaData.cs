using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea.Models
{
    internal interface ISafeAreaData
    {
        Rect SafeArea { get; }
        float OffsetTop { get; }
        float OffsetBottom { get; }
        float OffsetLeft { get; }
        float OffsetRight { get; }
        void ChangeRatio(float ratioX, float ratioY);
    }
}