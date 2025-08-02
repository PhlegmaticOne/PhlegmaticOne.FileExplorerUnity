using JetBrains.Annotations;

namespace PhlegmaticOne.FileExplorer.Configuration
{
    public enum ExplorerIconsLoadType
    {
        UseInBuildIconsAlways = 1,
        PreviewImagesInsteadOnIcons = 2,
        [UsedImplicitly]
        LoadFromServerWithLocalIconsFallback = 3
    }
}