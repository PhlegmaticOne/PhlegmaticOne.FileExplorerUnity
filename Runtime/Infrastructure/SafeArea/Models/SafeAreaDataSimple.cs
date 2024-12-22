using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea
{
    internal sealed class SafeAreaDataSimple : SafeAreaDataBase
    {
        public SafeAreaDataSimple()
        {
            OffsetTop = Screen.height - Screen.safeArea.yMax;
            OffsetBottom = Screen.safeArea.yMin;
            OffsetLeft = Screen.safeArea.xMin;
            OffsetRight = Screen.width - Screen.safeArea.xMax;
        }
    }
}