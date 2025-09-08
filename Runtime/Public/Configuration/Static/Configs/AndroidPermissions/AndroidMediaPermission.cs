using System;

namespace PhlegmaticOne.FileExplorer.Configuration.Configs.AndroidPermissions
{
    [Flags]
    public enum AndroidMediaPermission
    {
        None = 0,
        Images = 1,
        Audio = 2,
        Video = 4
    }
}