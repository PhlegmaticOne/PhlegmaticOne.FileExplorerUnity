using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public sealed class ExplorerShowConfiguration
    {
        private Camera _camera;
        
        public int OrderInLayer { get; private set; }
        public string SortingLayerName { get; private set; } = "Default";
        public string StartupLocation { get; private set; } = string.Empty;
        public ExplorerShowTypePayload ShowTypePayload { get; private set; } = ExplorerShowTypePayload.InvestigateFiles();

        public ExplorerShowConfiguration WithCamera(Camera camera)
        {
            _camera = camera;
            return this;
        }

        public ExplorerShowConfiguration WithSortingLayerName(string sortingLayerName)
        {
            SortingLayerName = sortingLayerName;
            return this;
        }

        public ExplorerShowConfiguration WithOrderInLayer(int orderIndex)
        {
            OrderInLayer = orderIndex;
            return this;
        }

        public ExplorerShowConfiguration WithStartupLocation(string startupLocation)
        {
            StartupLocation = startupLocation;
            return this;
        }

        public ExplorerShowConfiguration WithShowPayload(ExplorerShowTypePayload showPayload)
        {
            ShowTypePayload = showPayload;
            return this;
        }

        internal Camera GetCamera()
        {
            return _camera == null ? Camera.main : _camera;
        }
    }
}