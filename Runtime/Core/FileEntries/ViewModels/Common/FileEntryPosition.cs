using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries
{
    internal sealed class FileEntryPosition
    {
        public Vector2 AnchoredPosition { get; private set; }
        public Vector2 Size { get; private set; }
        
        public void Update(Vector2 worldPosition, Vector2 size)
        {
            Size = size;
            AnchoredPosition = worldPosition;
        }

        public static float HalfScreenWidth()
        {
            return (float)Screen.width / 2;
        }
    }
}