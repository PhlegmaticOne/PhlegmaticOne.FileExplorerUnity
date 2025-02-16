using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Scene
{
    internal sealed class FileViewSceneService : IFileViewSceneService
    {
        private readonly RectTransform _headerTransform;

        public FileViewSceneService(ScrollRect scrollRect, RectTransform headerTransform)
        {
            ScrollRect = scrollRect;
            _headerTransform = headerTransform;
        }

        public ScrollRect ScrollRect { get; }

        public float GetOffset()
        {
            return _headerTransform.rect.height;
        }
    }
}