using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Services.Scene
{
    internal interface ISceneService
    {
        ScrollRect ScrollRect { get; }
        float GetHeaderOffset();
        float GetSafeZoneOffset();
    }
}