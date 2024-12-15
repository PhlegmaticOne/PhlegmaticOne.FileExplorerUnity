using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Files;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files
{
    internal sealed class FileViewModel : FileEntryViewModel
    {
        private readonly ExplorerFileIcon _fileIcon;
        
        public FileViewModel(
            string path, string name, string extension,
            IExplorerIconsProvider iconsProvider,
            FileEntryActionsProvider actionsProvider,
            IFileOperations fileOperations) : 
            base(path, name, iconsProvider, actionsProvider, fileOperations)
        {
            Extension = extension;
            _fileIcon = new ExplorerFileIcon(this, iconsProvider);
        }

        public string Extension { get; }
        
        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await _fileIcon.EnsureLoadedAsync(cancellationToken);
            Icon.SetIcon(_fileIcon.GetIcon());
        }

        public override Dictionary<string, string> GetProperties()
        {
            var properties = new FileProperties(Path);
            var baseProperties = properties.GetBaseProperties();
            baseProperties.Add("Directory", properties.Directory);
            baseProperties.Add("Extension", properties.Extension);
            baseProperties.Add("Size", properties.Size.BuildUnitView());
            return baseProperties;
        }

        public override void Rename(string newName)
        {
            Path = FileOperations.RenameFile(Path, newName);
            Name.SetValueNotify(newName + Extension);
        }

        public override void Delete()
        {
            FileOperations.DeleteFile(Path);
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