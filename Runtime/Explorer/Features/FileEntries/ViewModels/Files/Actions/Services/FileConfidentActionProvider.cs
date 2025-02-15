using System;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Popups.FileView;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileConfidentActionProvider : IFileConfidentActionProvider
    {
        private readonly IFileEntryActionsFactory _factory;

        public FileConfidentActionProvider(IFileEntryActionsFactory factory)
        {
            _factory = factory;
        }
        
        public bool TryGetConfidentAction(FileViewModel file, out ActionViewModel action)
        {
            if (!file.Extension.IsViewable(out var viewType))
            {
                action = null;
                return false;
            }

            action = CreateAction(viewType, file);
            return true;
        }

        private ActionViewModel CreateAction(FileViewType viewType, FileViewModel file)
        {
            return viewType switch
            {
                FileViewType.Image => _factory.ShowImage(file),
                FileViewType.Text => _factory.ShowText(file),
                FileViewType.Audio => _factory.ShowAudio(file),
                _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
            };
        }
    }
}