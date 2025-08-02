using System;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.Entities.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions
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

        private ActionViewModel CreateAction(FileContentType contentType, FileEntryViewModel file)
        {
            return contentType switch
            {
                FileContentType.Image => _factory.ShowImage(file),
                FileContentType.Text => _factory.ShowText(file),
                FileContentType.Audio => _factory.ShowAudio(file),
                _ => throw new ArgumentOutOfRangeException(nameof(contentType), contentType, null)
            };
        }
    }
}