using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons
{
    internal sealed class ExplorerIconData
    {
        public void SetIcon(Sprite icon)
        {
            IconSprite = icon;
        }

        public Sprite IconSprite { get; private set; }
        public float Aspect => IconSprite.CalculateAspect();
    }
}