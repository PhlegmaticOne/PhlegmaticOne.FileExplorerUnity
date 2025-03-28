﻿using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Extensions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Properties;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files
{
    internal sealed class FileViewModel : FileEntryViewModel
    {
        private readonly IFileViewModelClickCommand _clickCommand;
        private readonly ExplorerFileIcon _fileIcon;
        
        public FileViewModel(
            string name, string path, string extension,
            IExplorerIconsProvider iconsProvider,
            IFileViewModelClickCommand clickCommand,
            SelectionViewModel selectionViewModel,
            IFileOperations fileOperations,
            IFileExtensions fileExtensions) : 
            base(name, path, iconsProvider, selectionViewModel, fileOperations)
        {
            _clickCommand = clickCommand;
            Extension = new FileExtension(fileExtensions, extension);
            _fileIcon = new ExplorerFileIcon(this, iconsProvider);
        }

        public FileExtension Extension { get; }

        public override FileEntryType EntryType => FileEntryType.File;

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await _fileIcon.EnsureLoadedAsync(cancellationToken);
            Icon.SetIcon(_fileIcon.GetIcon());
        }

        public override FileEntryProperties GetProperties()
        {
            return new FileProperties(Path);
        }

        public override void Rename(string newName)
        {
            Path = FileOperations.RenameFile(Path, newName);
            Name.SetValueNotify(newName + Extension.Value);
        }

        public override void Delete()
        {
            FileOperations.DeleteFile(Path);
        }

        public override bool Exists()
        {
            return FileOperations.FileExists(Path);
        }

        protected override void OnClick(ActionTargetViewPosition position)
        {
            _clickCommand.OnClick(this, position);
        }

        public override void Dispose()
        {
            _fileIcon.Dispose();
        }
    }
}