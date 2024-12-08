using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons
{
    internal readonly struct ExplorerIconData
    {
        public ExplorerIconData(Sprite icon)
        {
            Icon = icon;
        }

        public Sprite Icon { get; }
        public float Aspect => Icon.CalculateAspect();
    }
}