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
        
        public async Task<FileRenameResult> GetRenameData(FileEntryViewModel file)
        {
            var viewModel = _container
                .Instantiate<RenamePopupViewModel>()
                .Setup(GetInitialInputText(file), GetRenameHeader(file));

            await _popupProvider.Show<RenamePopup, RenamePopupViewModel>(viewModel);
            
            return new FileRenameResult(viewModel.OutputText, !viewModel.IsDiscarded);
        }

        private static string GetInitialInputText(FileEntryViewModel viewModel)
        {
            return System.IO.Path.GetFileNameWithoutExtension(viewModel.Path);
        }

        private static string GetRenameHeader(FileEntryViewModel viewModel)
        {
            return $"Rename {viewModel.EntryType.ToString().ToLower()}";
        }
    }
}