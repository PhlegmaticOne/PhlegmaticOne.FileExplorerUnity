using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons
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