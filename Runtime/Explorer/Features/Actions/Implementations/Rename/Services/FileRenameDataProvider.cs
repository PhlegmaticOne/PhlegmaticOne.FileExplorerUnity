using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services
{
    internal sealed class FileRenameDataProvider : IFileRenameDataProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FileRenameDataProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public async Task<FileEntryRenameDataResult> GetRenameData(FileEntryViewModel viewModel)
        {
            var inputViewModel = new RenameInputPopupViewModel
            {
                HeaderText = GetRenameHeader(viewModel),
                OutputText = string.Empty,
                AcceptButtonText = "Rename",
                InitialInputText = System.IO.Path.GetFileNameWithoutExtension(viewModel.Path)
            };

            await _popupProvider.Show<RenameInputPopup, RenameInputPopupViewModel>(inputViewModel);
            
            return new FileEntryRenameDataResult(inputViewModel.OutputText, !inputViewModel.IsDiscarded);
        }

        private static string GetRenameHeader(FileEntryViewModel viewModel)
        {
            return $"Rename {viewModel.EntryType.ToString().ToLower()}";
        }
    }
}