using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Services.Scene
{
    internal sealed class SceneService : ISceneService
    {
        private readonly RectTransform _headerTransform;
        private readonly VerticalLayoutGroup _safeZoneLayout;

        public SceneService(ScrollRect scrollRect, RectTransform headerTransform, VerticalLayoutGroup safeZoneLayout)
        {
            ScrollRect = scrollRect;
            _headerTransform = headerTransform;
            _safeZoneLayout = safeZoneLayout;
        }

        public ScrollRect ScrollRect { get; }

        public float GetHeaderOffset()
        {
            return _headerTransform.rect.height;
        }

        public float GetSafeZoneOffset()
        {
            return _safeZoneLayout.padding.top;
        }
    }
}