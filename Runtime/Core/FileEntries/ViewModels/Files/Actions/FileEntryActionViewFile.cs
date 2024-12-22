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
        private readonly IFileViewContentProvider _fileViewContentProvider;
        private readonly FileViewType _viewType;
        private readonly Color _textColor;

        public FileEntryActionViewFile(
            IFileViewContentProvider fileViewContentProvider,
            ActionsViewModel actionsViewModel,
            FileViewType viewType,
            Color textColor) : base(actionsViewModel)
        {
            _fileViewContentProvider = fileViewContentProvider;
            _viewType = viewType;
            _textColor = textColor;
        }

        public override string Description => $"View as {_viewType}";
        
        public override FileEntryActionColor Color => FileEntryActionColor.WithTextColor(_textColor);
        
        protected override async Task<bool> ExecuteAction()
        {
            await _fileViewContentProvider.ViewFileAsync((FileViewModel)FileEntry, _viewType);
            return true;
        }
    }
}