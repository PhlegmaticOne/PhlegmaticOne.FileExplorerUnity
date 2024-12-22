using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Rename
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
            var inputViewModel = new InputPopupViewModel
            {
                HeaderText = GetRenameHeader(viewModel),
                OutputText = string.Empty,
                AcceptButtonText = "Rename",
                InitialInputText = Path.GetFileNameWithoutExtension(viewModel.Path)
            };

            await _popupProvider.Show<InputPopup, InputPopupViewModel>(inputViewModel);
            
            return new FileEntryRenameDataResult(
                inputViewModel.OutputText, 
                !inputViewModel.IsDiscarded);
        }

        private static string GetRenameHeader(FileEntryViewModel viewModel)
        {
            return $"Rename {viewModel.EntryType}";
        }
    }
}