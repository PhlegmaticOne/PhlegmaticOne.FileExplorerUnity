using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Services.RootObject
{
    internal interface IExplorerRootObjectProvider
    {
        GameObject RootObject { get; }
    }
}