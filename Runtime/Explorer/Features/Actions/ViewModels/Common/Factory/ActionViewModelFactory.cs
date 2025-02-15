using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common.Factory
{
    internal sealed class ActionViewModelFactory : IActionViewModelFactory
    {
        private readonly IDependencyContainer _container;

        public ActionViewModelFactory(IDependencyContainer container)
        {
            _container = container;
        }
        
        public ActionViewModel Create<T>(string key) where T : class, IActionCommand
        {
            var action = _container.Instantiate<T>();
            return _container.Instantiate<ActionViewModelCommon>(key, action);
        }
    }
}