using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Core
{
    internal sealed class ActionViewModelFactory : IActionViewModelFactory
    {
        private readonly IDependencyContainer _container;

        public ActionViewModelFactory(IDependencyContainer container)
        {
            _container = container;
        }
        
        public ActionViewModel Create<T>(string key) where T : class, IAction
        {
            var action = _container.Instantiate<T>();
            var actionCommand = _container.Instantiate<ActionCommand>(action);
            return _container.Instantiate<ActionViewModel>(key, actionCommand);
        }
    }
}