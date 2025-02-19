using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Services.Scene
{
    internal sealed class SceneService : ISceneService
    {
        private readonly RectTransform _headerTransform;
        private readonly VerticalLayoutGroup _safeZoneLayout;

        public SceneService(RectTransform headerTransform, VerticalLayoutGroup safeZoneLayout)
        {
            _headerTransform = headerTransform;
            _safeZoneLayout = safeZoneLayout;
        }

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