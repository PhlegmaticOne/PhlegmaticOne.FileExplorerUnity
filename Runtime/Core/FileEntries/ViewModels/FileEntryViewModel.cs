using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels
{
    internal abstract class FileEntryViewModel : IDisposable
    {
        protected readonly IExplorerIconsProvider IconsProvider;

        protected FileEntryViewModel(string path, string name, IExplorerIconsProvider iconsProvider)
        {
            Path = path;
            Name = name;
            IconsProvider = iconsProvider;
        }

        public string Path { get; }
        public string Name { get; }

        public abstract Task InitializeAsync(CancellationToken cancellationToken);
        public abstract ExplorerIconData GetIcon();
        public abstract void OnClick();
        public abstract void Dispose();

        public void OnHoldClick()
        {
        }

        protected abstract IEnumerable<IFileEntryAction> GetActions();
    }
}