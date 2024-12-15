using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;
using PhlegmaticOne.FileExplorer.Infrastructure.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal abstract class FileEntryViewModel : IDisposable
    {
        protected readonly IExplorerIconsProvider IconsProvider;
        protected readonly IFileOperations FileOperations;

        private readonly FileEntryActionsProvider _actionsProvider;

        protected FileEntryViewModel(
            string path, string name,
            IExplorerIconsProvider iconsProvider,
            FileEntryActionsProvider actionsProvider,
            IFileOperations fileOperations)
        {
            Path = path;
            Name = new ReactiveProperty<string>(name);
            Position = new FileEntryPosition();
            Icon = new ExplorerIconData();
            IconsProvider = iconsProvider;
            FileOperations = fileOperations;
            _actionsProvider = actionsProvider;
        }

        public ReactiveProperty<string> Name { get; }
        public string Path { get; protected set; }
        public FileEntryPosition Position { get; }
        public ExplorerIconData Icon { get; }

        public abstract Task InitializeAsync(CancellationToken cancellationToken);
        public abstract void Rename(string newName);
        public abstract void Delete();
        public abstract void OnClick();
        public abstract void Dispose();
        
        public void OnHoldClick()
        {
            _actionsProvider.ShowActions(this);
        }
    }
}