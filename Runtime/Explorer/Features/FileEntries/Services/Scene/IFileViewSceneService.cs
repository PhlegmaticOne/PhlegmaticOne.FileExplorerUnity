using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Scene
{
    internal interface IFileViewSceneService
    {
        ScrollRect ScrollRect { get; }
        float GetOffset();
    }
}