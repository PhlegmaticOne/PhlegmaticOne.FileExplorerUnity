using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal abstract class FileEntryViewModel : IDisposable
    {
        protected readonly IExplorerIconsProvider IconsProvider;
        
        private readonly FileEntryActionsProvider _actionsProvider;

        protected FileEntryViewModel(
            string path, string name, FileEntryPosition position,
            IExplorerIconsProvider iconsProvider,
            FileEntryActionsProvider actionsProvider)
        {
            Path = path;
            Name = new ReactiveProperty<string>(name);
            Position = position;
            IconsProvider = iconsProvider;
            _actionsProvider = actionsProvider;
        }

        public ReactiveProperty<string> Name { get; }
        public string Path { get; }
        public FileEntryPosition Position { get; }

        public abstract Task InitializeAsync(CancellationToken cancellationToken);
        public abstract ExplorerIconData GetIcon();
        public abstract void OnClick();
        public abstract void Dispose();
        
        public void OnHoldClick()
        {
            _actionsProvider.ShowActions(this);
        }
    }
}