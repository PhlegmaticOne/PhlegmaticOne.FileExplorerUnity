using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Positioning;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal sealed class FileViewModel : FileEntryViewModel
    {
        private readonly ExplorerFileIcon _fileIcon;
        
        public FileViewModel(
            string path, string name, string extension, FileEntryPosition position,
            IExplorerIconsProvider iconsProvider,
            FileEntryActionsProvider actionsProvider) : 
            base(path, name, position, iconsProvider, actionsProvider)
        {
            Extension = extension;
            _fileIcon = new ExplorerFileIcon(this, iconsProvider);
        }

        public string Extension { get; }
        
        public override Task InitializeAsync(CancellationToken cancellationToken)
        {
            return _fileIcon.EnsureLoadedAsync(cancellationToken);
        }

        public override ExplorerIconData GetIcon()
        {
            return new ExplorerIconData(_fileIcon.GetIcon());
        }

        public override void OnClick()
        {
            
        }

        public bool IsImage()
        {
            return Extension is ".png" or ".jpg";
        }

        public override void Dispose()
        {
            _fileIcon.Dispose();
        }
    }
}