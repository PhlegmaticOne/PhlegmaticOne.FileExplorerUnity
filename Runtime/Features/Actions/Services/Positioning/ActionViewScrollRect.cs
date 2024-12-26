using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning
{
    internal sealed class ActionViewScrollRect
    {
        public RectTransform ScrollRect { get; }

        public ActionViewScrollRect(RectTransform scrollRect)
        {
            ScrollRect = scrollRect;
        }
    }
}