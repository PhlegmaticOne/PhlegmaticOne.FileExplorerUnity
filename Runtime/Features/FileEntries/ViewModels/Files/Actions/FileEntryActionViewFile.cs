using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
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
        
        public override ActionColor Color => ActionColor.WithTextColor(_textColor);
        
        protected override async Task<bool> ExecuteAction()
        {
            await _fileViewContentProvider.ViewFileAsync((FileViewModel)FileEntry, _viewType);
            return true;
        }
    }
}