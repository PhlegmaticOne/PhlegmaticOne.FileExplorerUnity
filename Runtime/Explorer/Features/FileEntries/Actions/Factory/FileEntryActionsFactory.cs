using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
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
            var viewModel = _container.Instantiate<FileEntryActionViewModel>(key, file, action);
            return viewModel;
        }
    }
}