using UnityEngine;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal interface IExplorerRootObjectProvider
    {
        GameObject RootObject { get; }
    }
}