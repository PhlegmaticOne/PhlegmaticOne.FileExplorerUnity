using System.Threading.Tasks;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public interface IExplorer
    {
        Task<ExplorerShowResult> Open(ExplorerShowParameters parameters);
    }

    public sealed class ExplorerShowParameters
    {
        public Camera Camera { get; private set; }
        public int OrderInLayer { get; private set; }
        public string SortingLayerName { get; private set; } = "Default";

        public ExplorerShowParameters WithCamera(Camera camera)
        {
            Camera = camera;
            return this;
        }

        public ExplorerShowParameters WithSortingLayerName(string sortingLayerName)
        {
            SortingLayerName = sortingLayerName;
            return this;
        }

        public ExplorerShowParameters WithOrderInLayer(int orderIndex)
        {
            OrderInLayer = orderIndex;
            return this;
        }

        internal Camera GetCamera()
        {
            return Camera == null ? Camera.main : Camera;
        }
    }
    
    public sealed class ExplorerShowResult
    {
        public static ExplorerShowResult Showed()
        {
            return new ExplorerShowResult(isShowed: true);
        }
        
        public static ExplorerShowResult NotShowed()
        {
            return new ExplorerShowResult(isShowed: false);
        }

        public ExplorerShowResult(bool isShowed)
        {
            IsShowed = isShowed;
        }

        public bool IsShowed { get; }
    }
}