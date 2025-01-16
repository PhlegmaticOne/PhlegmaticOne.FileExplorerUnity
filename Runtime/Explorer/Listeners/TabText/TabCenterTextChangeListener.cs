using PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Listeners.TabText
{
    internal sealed class TabCenterTextChangeListener : IExplorerActionListener
    {
        private readonly ScreenMessagesViewModel _screenMessagesViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly TabViewModel _tabViewModel;

        public TabCenterTextChangeListener(
            ScreenMessagesViewModel screenMessagesViewModel,
            SearchViewModel searchViewModel,
            TabViewModel tabViewModel)
        {
            _screenMessagesViewModel = screenMessagesViewModel;
            _searchViewModel = searchViewModel;
            _tabViewModel = tabViewModel;
        }

        public void StartListen()
        {
            _searchViewModel.FoundEntriesCount.ValueChanged += UpdateFoundEntriesCount;
            _tabViewModel.IsEmpty.ValueChanged += UpdateMessageOnTabEmptyChanged;
        }

        public void StopListen()
        {
            _searchViewModel.FoundEntriesCount.ValueChanged -= UpdateFoundEntriesCount;
            _tabViewModel.IsEmpty.ValueChanged -= UpdateMessageOnTabEmptyChanged;
        }

        private void UpdateMessageOnTabEmptyChanged(bool _)
        {
            UpdateTabCenterMessage();
        }

        private void UpdateFoundEntriesCount(int _)
        {
            UpdateTabCenterMessage();
        }

        private void UpdateTabCenterMessage()
        {
            if (_searchViewModel.IsActive && _searchViewModel.FoundEntriesCount == 0)
            {
                SetTabMessage($"Tab has no entries containing \"{_searchViewModel.SearchText}\"");
                return;
            }

            if (_tabViewModel.IsEmpty)
            {
                SetTabMessage("Directory is empty!");
                return;
            }
            
            _screenMessagesViewModel.IsTabCenterMessageActive.SetValueNotify(false);
        }

        private void SetTabMessage(string message)
        {
            var data = new ScreenMessageData(message, Color.white);
            _screenMessagesViewModel.IsTabCenterMessageActive.SetValueNotify(true);
            _screenMessagesViewModel.TabCenterMessage.SetValueNotify(data);
        }
    }
}