using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Features.Views.Input;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Rename
{
    internal sealed class FileRenameDataProvider : IFileEntryRenameDataProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FileRenameDataProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public async Task<FileEntryRenameDataResult> GetRenameData(FileEntryViewModel viewModel)
        {
            var inputViewModel = new InputViewModel
            {
                HeaderText = GetRenameHeader(viewModel),
                OutputText = string.Empty,
                AcceptButtonText = "Rename",
                InitialInputText = Path.GetFileNameWithoutExtension(viewModel.Path)
            };

            await _popupProvider.Show<InputPopup, InputViewModel>(inputViewModel);
            
            return new FileEntryRenameDataResult(
                inputViewModel.OutputText, 
                !inputViewModel.IsDiscarded);
        }

        private static string GetRenameHeader(FileEntryViewModel viewModel)
        {
            return viewModel switch
            {
                DirectoryViewModel => "Rename directory",
                Core.FileEntries.ViewModels.Files.FileViewModel => "Rename file",
                _ => "Rename"
            };
        }
    }
}