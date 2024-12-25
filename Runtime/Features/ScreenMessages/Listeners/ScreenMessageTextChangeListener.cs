using PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Services
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
        }

        public void StartListen()
        {
            _searchViewModel.FoundEntriesCount.ValueChanged += UpdateFoundEntriesCount;
            _searchViewModel.IsActive.ValueChanged += UpdateSearchHeaderTextActive;
            _tabViewModel.IsEmpty.ValueChanged += UpdateMessageOnTabEmptyChanged;
        }

        public void StopListen()
        {
            _searchViewModel.FoundEntriesCount.ValueChanged -= UpdateFoundEntriesCount;
            _searchViewModel.IsActive.ValueChanged -= UpdateSearchHeaderTextActive;
            _tabViewModel.IsEmpty.ValueChanged -= UpdateMessageOnTabEmptyChanged;
        }

        private void UpdateMessageOnTabEmptyChanged(bool _)
        {
            UpdateTabCenterMessage();
        }

        private void UpdateSearchHeaderTextActive(bool isActive)
        {
            _screenMessagesViewModel.IsHeaderMessageActive.SetValueNotify(isActive);
            UpdateTabCenterMessage();
        }

        private void UpdateFoundEntriesCount(int foundEntriesCount)
        {
            if (foundEntriesCount != -1)
            {
                SetHeaderMessage($"Found entries: {foundEntriesCount}");
            }
            
            UpdateTabCenterMessage();
        }

        private void UpdateTabCenterMessage()
        {
            if (_searchViewModel.IsActive && _searchViewModel.FoundEntriesCount == 0)
            {
                SetTabMessage($"There are no entries containing \"{_searchViewModel.SearchText}\"");
                return;
            }

            if (_tabViewModel.IsEmpty)
            {
                SetTabMessage("Directory is empty!");
                return;
            }
            
            _screenMessagesViewModel.IsTabCenterMessageActive.SetValueNotify(false);
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