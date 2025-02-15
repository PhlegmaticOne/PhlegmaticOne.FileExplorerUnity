using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions
{
    internal sealed class FileEntryActionsFactory : IFileEntryActionsFactory
    {
        private readonly IDependencyContainer _container;

        public FileEntryActionsFactory(IDependencyContainer container)
        {
            _container = container;
        }
        
        public ActionViewModel Create<T>(string key, FileEntryViewModel file) where T : class, IFileEntryAction
        {
            var action = _container.Instantiate<T>();
            var actionCommand = _container.Instantiate<FileEntryActionCommand>(file, action);
            var viewModel = _container.Instantiate<ActionViewModel>(key, actionCommand);
            return viewModel;
        }
    }
}