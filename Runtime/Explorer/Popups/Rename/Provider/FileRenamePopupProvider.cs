using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class FileRenamePopupProvider : IFileRenamePopupProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;

        public FileRenamePopupProvider(
            IDependencyContainer container,
            IPopupProvider popupProvider)
        {
            _container = container;
            _popupProvider = popupProvider;
        }
        
        public async Task<FileRenameResult> GetRenameData(FileEntryViewModel viewModel)
        {
            var inputViewModel = _container.Instantiate<RenamePopupViewModel>();
            
            inputViewModel.Setup(
                initialInputText: System.IO.Path.GetFileNameWithoutExtension(viewModel.Path),
                headerText: GetRenameHeader(viewModel));

            await _popupProvider.Show<RenamePopup, RenamePopupViewModel>(inputViewModel);
            
            return new FileRenameResult(inputViewModel.OutputText, !inputViewModel.IsDiscarded);
        }

        private static string GetRenameHeader(FileEntryViewModel viewModel)
        {
            return $"Rename {viewModel.EntryType.ToString().ToLower()}";
        }
    }
}