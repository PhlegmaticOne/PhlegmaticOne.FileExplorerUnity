using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public sealed class ExplorerSceneConfiguration
    {
        private Camera _camera;
        
        public int OrderInLayer { get; private set; }
        public string SortingLayerName { get; private set; }

        public static ExplorerSceneConfiguration Default()
        {
            return new ExplorerSceneConfiguration
            {
                OrderInLayer = 100,
                SortingLayerName = "Default"
            };
        }

        public ExplorerSceneConfiguration WithCamera(Camera camera)
        {
            _camera = camera;
            return this;
        }

        public ExplorerSceneConfiguration WithSortingLayerName(string sortingLayerName)
        {
            SortingLayerName = sortingLayerName;
            return this;
        }

        public ExplorerSceneConfiguration WithOrderInLayer(int orderIndex)
        {
            OrderInLayer = orderIndex;
            return this;
        }

        internal Camera GetCamera()
        {
            return _camera == null ? Camera.main : _camera;
        }
    }
}