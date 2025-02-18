using JetBrains.Annotations;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal enum ReactiveCollectionChangedAction
    {
        [UsedImplicitly]
        None = 0,
        Add = 1,
        Remove = 2,
        Reset = 3
    }
}