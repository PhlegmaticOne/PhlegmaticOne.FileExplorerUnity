namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common.Factory
{
    internal interface IActionViewModelFactory
    {
        ActionViewModel Create<T>(string key) where T : class, IActionCommand;
    }
}