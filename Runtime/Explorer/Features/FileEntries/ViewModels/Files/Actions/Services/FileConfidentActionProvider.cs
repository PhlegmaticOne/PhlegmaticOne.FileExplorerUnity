using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Popups.FileView;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileConfidentActionProvider : IFileConfidentActionProvider
    {
        private readonly IDependencyContainer _dependencyContainer;

        public FileConfidentActionProvider(IDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }
        
        public bool TryGetConfidentAction(FileViewModel file, out FileEntryAction action)
        {
            if (!file.Extension.IsViewable(out var viewType))
            {
                action = null;
                return false;
            }

            action = CreateAction(viewType, file);
            return true;
        }

        private FileEntryAction CreateAction(FileViewType viewType, FileViewModel file)
        {
            return viewType switch
            {
                FileViewType.Image => _dependencyContainer.Instantiate<FileEntryActionShowImage>(file),
                FileViewType.Text => _dependencyContainer.Instantiate<FileEntryActionShowText>(file),
                FileViewType.Audio => _dependencyContainer.Instantiate<FileEntryActionPlayAudio>(file),
                _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
            };
        }
    }
}