using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Services.ActionListeners;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Listeners
{
    internal sealed class TabEntriesAddedListener : IExplorerActionListener
    {
        private readonly TabViewModel _tabViewModel;
        private readonly ITabEntriesAddedHandler[] _handlers;

        public TabEntriesAddedListener(TabViewModel tabViewModel, ITabEntriesAddedHandler[] handlers)
        {
            _tabViewModel = tabViewModel;
            _handlers = handlers;
        }
        
        public void Start()
        {
            _tabViewModel.FileEntries.CollectionChanged += HandleEntriesAdded;
        }

        public void Stop()
        {
            _tabViewModel.FileEntries.CollectionChanged -= HandleEntriesAdded;
        }

        private void HandleEntriesAdded(ReactiveCollectionChangedEventArgs<FileEntryViewModel> eventArgs)
        {
            if (eventArgs.Action != ReactiveCollectionChangedAction.Add)
            {
                return;
            }

            foreach (var handler in _handlers)
            {
                handler.HandleEntriesAdded(eventArgs.AffectedItems);
            }
        }
    }
}