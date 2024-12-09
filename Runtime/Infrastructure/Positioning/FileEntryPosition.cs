using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Positioning
{
    internal sealed class FileEntryPosition
    {
        private readonly Camera _camera;

        public FileEntryPosition(Camera camera)
        {
            _camera = camera;
        }
        
        public Vector2 AnchoredPosition { get; private set; }
        public Vector2 Size { get; private set; }
        
        public void Update(Vector2 worldPosition, Vector2 size)
        {
            Size = size;
            AnchoredPosition = worldPosition;
        }

        public Vector2 ToWorldUnits(Vector2 screenSize)
        {
            var cameraHeight = _camera.orthographicSize * 2;
            var cameraWidth = cameraHeight * _camera.aspect;
            var yWorldUnits = screenSize.y * cameraHeight / Screen.height;
            var xWorldUnits = screenSize.x * cameraWidth / Screen.width;
            return new Vector2(xWorldUnits, yWorldUnits);
        }

        public static float HalfScreenWidth()
        {
            return (float)Screen.width / 2;
        }
    }
}