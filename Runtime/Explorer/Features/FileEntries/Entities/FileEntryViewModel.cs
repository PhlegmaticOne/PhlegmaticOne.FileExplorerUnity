using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal abstract class FileEntryViewModel : ViewModel, IDisposable
    {
        protected readonly IExplorerIconsProvider IconsProvider;
        protected readonly SelectionViewModel SelectionViewModel;
        protected readonly IFileOperations FileOperations;

        protected FileEntryViewModel(
            string name, string path,
            IExplorerIconsProvider iconsProvider,
            SelectionViewModel selectionViewModel,
            IFileOperations fileOperations)
        {
            Path = path;
            Name = new ReactiveProperty<string>(name);
            IsSelected = new ReactiveProperty<bool>(false);
            IsActive = new ReactiveProperty<bool>(true);
            Icon = new ExplorerIconData();
            IconsProvider = iconsProvider;
            SelectionViewModel = selectionViewModel;
            FileOperations = fileOperations;

            ClickCommand = new CommandDelegate<FileEntryPosition>(OnClick);
            HoldClickCommand = new CommandDelegateEmpty(OnHoldClick);
        }

        public abstract FileEntryType EntryType { get; }
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<bool> IsSelected { get; }
        public ReactiveProperty<bool> IsActive { get; }
        public string Path { get; protected set; }
        public ExplorerIconData Icon { get; }
        public ICommand ClickCommand { get; }
        public ICommand HoldClickCommand { get; }
        
        public abstract Task InitializeAsync(CancellationToken cancellationToken);
        public abstract FileEntryProperties GetProperties();
        public abstract void Rename(string newName);
        public abstract void Delete();
        public abstract bool Exists();
        public abstract void Dispose();
        protected abstract void OnClick(FileEntryPosition position);

        private void OnHoldClick()
        {
            if (!SelectionViewModel.IsSelectionActive)
            {
                SelectionViewModel.UpdateSelection(this);
            }
        }
    }
}