using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories.Properties;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories
{
    internal sealed class DirectoryViewModel : FileEntryViewModel
    {
        private const string DirectoryExtension = "directory";

        private readonly IDirectoryViewModelClickCommand _clickCommand;
        private readonly IDirectoryViewModelHoldClickCommand _holdClickCommand;

        public DirectoryViewModel(
            string name, string path,
            IExplorerIconsProvider iconsProvider, 
            IDirectoryViewModelClickCommand clickCommand,
            IDirectoryViewModelHoldClickCommand holdClickCommand,
            IFileOperations fileOperations) : 
            base(name, path, iconsProvider, fileOperations)
        {
            _clickCommand = clickCommand;
            _holdClickCommand = holdClickCommand;
        }

        public override FileEntryType EntryType => FileEntryType.Directory;

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            var directoryIcon = await IconsProvider.GetIconAsync(DirectoryExtension, cancellationToken);
            Icon.SetIcon(directoryIcon);
        }

        public override FileEntryProperties GetProperties()
        {
            return new DirectoryProperties(Path);
        }

        public override void Rename(string newName)
        {
            Path = FileOperations.RenameDirectory(Path, newName);
            Name.SetValueNotify(newName);
        }

        public override void Delete()
        {
            FileOperations.DeleteDirectory(Path);
        }

        public override bool Exists()
        {
            return FileOperations.DirectoryExists(Path);
        }

        protected override void OnClick(ActionTargetViewPosition position)
        {
            _clickCommand.OnClick(this, position);
        }

        protected override void OnHoldClick()
        {
            _holdClickCommand.OnHoldClick(this);
        }

        public override void Dispose()
        {
            Icon.SetIcon(null);
        }
    }
}