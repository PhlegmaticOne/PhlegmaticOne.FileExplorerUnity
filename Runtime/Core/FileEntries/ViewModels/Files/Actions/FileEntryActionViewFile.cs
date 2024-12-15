using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Services;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files
{
    internal sealed class FileEntryActionViewFile : FileEntryAction
    {
        private readonly FileViewModel _viewModel;
        private readonly FileViewType _viewType;
        private readonly Color _textColor;
        private readonly IFileViewProvider _fileViewProvider;

        public FileEntryActionViewFile(
            FileViewModel viewModel, FileViewType viewType, Color textColor,
            IFileViewProvider fileViewProvider,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _viewModel = viewModel;
            _viewType = viewType;
            _textColor = textColor;
            _fileViewProvider = fileViewProvider;
        }

        public override string Description => $"View as {_viewType}";
        
        public override FileEntryActionColor Color => FileEntryActionColor.WithTextColor(_textColor);
        
        protected override async Task<bool> ExecuteAction()
        {
            await _fileViewProvider.ViewFileAsync(_viewModel, _viewType);
            return true;
        }
    }
}