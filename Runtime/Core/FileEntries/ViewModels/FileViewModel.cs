using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal sealed class FileViewModel : FileEntryViewModel
    {
        private readonly ExplorerFileIcon _fileIcon;
        
        public FileViewModel(
            string path, string name, string extension,
            IExplorerIconsProvider iconsProvider) : 
            base(path, name, iconsProvider)
        {
            Extension = extension;
            _fileIcon = new ExplorerFileIcon(this, iconsProvider);
        }

        public string Extension { get; }
        
        public override Task InitializeAsync()
        {
            return _fileIcon.EnsureLoadedAsync();
        }

        public override ExplorerIconData GetIcon()
        {
            return new ExplorerIconData(_fileIcon.GetIcon());
        }

        public override void OnClick()
        {
            
        }

        protected override IEnumerable<IFileEntryAction> GetActions()
        {
            yield break;
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