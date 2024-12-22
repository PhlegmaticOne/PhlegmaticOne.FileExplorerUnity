using PhlegmaticOne.FileExplorer.Core.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.ScreenMessages.Services
{
    internal sealed class ScreenMessageTextChangeListener : IScreenMessageTextChangeListener
    {
        private readonly ScreenMessagesViewModel _screenMessagesViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly TabViewModel _tabViewModel;

        public ScreenMessageTextChangeListener(
            ScreenMessagesViewModel screenMessagesViewModel,
            SearchViewModel searchViewModel,
            TabViewModel tabViewModel)
        {
            _screenMessagesViewModel = screenMessagesViewModel;
            _searchViewModel = searchViewModel;
            _tabViewModel = tabViewModel;
            StartListen();
        }

        public void StartListen()
        {
            _searchViewModel.IsActive.ValueChanged += UpdateMessageOnSearchActiveChanged;
            _tabViewModel.IsEmpty.ValueChanged += UpdateMessageOnTabEmptyChanged;
        }

        public void StopListen()
        {
            _searchViewModel.IsActive.ValueChanged -= UpdateMessageOnSearchActiveChanged;
            _tabViewModel.IsEmpty.ValueChanged -= UpdateMessageOnTabEmptyChanged;
        }

        private void UpdateMessageOnTabEmptyChanged(bool isEmpty)
        {
            UpdateMessage(isEmpty, _searchViewModel.IsActive);
        }

        private void UpdateMessageOnSearchActiveChanged(bool isActive)
        {
            UpdateFoundEntriesCountText(isActive);
            UpdateMessage(_tabViewModel.IsEmpty, isActive);
        }

        private void UpdateMessage(bool isTabEmpty, bool isSearchActive)
        {
            if (isSearchActive && _searchViewModel.FoundEntriesCount == 0)
            {
                SetTabMessage("Search result is empty!");
                return;
            }

            if (isTabEmpty)
            {
                SetTabMessage("Directory is empty!");
                return;
            }
            
            _screenMessagesViewModel.IsTabCenterMessageActive.SetValueNotify(false);
        }

        private void UpdateFoundEntriesCountText(bool isActive)
        {
            _screenMessagesViewModel.IsHeaderMessageActive.SetValueNotify(isActive);

            if (isActive)
            {
                var found = _searchViewModel.FoundEntriesCount;
                SetHeaderMessage($"Found entries: {found}");
            }
        }

        private void SetHeaderMessage(string message)
        {
            var data = new ScreenMessageData(message, Color.white);
            _screenMessagesViewModel.HeaderMessage.SetValueNotify(data);
        }

        private void SetTabMessage(string message)
        {
            var data = new ScreenMessageData(message, Color.white);
            _screenMessagesViewModel.IsTabCenterMessageActive.SetValueNotify(true);
            _screenMessagesViewModel.TabCenterMessage.SetValueNotify(data);
        }
    }
}