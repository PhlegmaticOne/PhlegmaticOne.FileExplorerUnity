using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class FileRenamePopupProvider : IFileRenamePopupProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FileRenamePopupProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public async Task<FileRenameResult> GetRenameData(FileEntryViewModel viewModel)
        {
            var inputViewModel = new RenamePopupViewModel
            {
                HeaderText = GetRenameHeader(viewModel),
                OutputText = string.Empty,
                AcceptButtonText = "Rename",
                InitialInputText = System.IO.Path.GetFileNameWithoutExtension(viewModel.Path)
            };

            await _popupProvider.Show<RenamePopup, RenamePopupViewModel>(inputViewModel);
            
            return new FileRenameResult(inputViewModel.OutputText, !inputViewModel.IsDiscarded);
        }

        private static string GetRenameHeader(FileEntryViewModel viewModel)
        {
            return $"Rename {viewModel.EntryType.ToString().ToLower()}";
        }
    }
}