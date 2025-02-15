using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Core
{
    internal interface IActionViewModelFactory
    {
        ActionViewModel Create<T>(string key) where T : class, IAction;
    }
}