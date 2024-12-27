using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.SafeArea
{
    internal sealed class SafeAreaInitializer : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;

        private void Awake()
        {
            var resolution = _canvasScaler.referenceResolution;
            Models.SafeArea.Initialize(resolution.x, resolution.y);
        }
    }
}