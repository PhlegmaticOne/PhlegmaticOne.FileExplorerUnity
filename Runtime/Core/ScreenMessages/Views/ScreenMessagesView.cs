using PhlegmaticOne.FileExplorer.Core.ScreenMessages.ViewModels;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.ScreenMessages.Views
{
    internal sealed class ScreenMessagesView : MonoBehaviour
    {
        [SerializeField] private GameObject _headerTextContainer;
        [SerializeField] private TextMeshProUGUI _headerText;

        [SerializeField] private GameObject _tabCenterTextContainer;
        [SerializeField] private TextMeshProUGUI _tabCenterText;
        
        private ScreenMessagesViewModel _viewModel;

        public void Bind(ScreenMessagesViewModel viewModel)
        {
            _viewModel = viewModel;
            
            _viewModel.IsHeaderMessageActive.ValueChanged += UpdateHeaderMessageIsActive;
            _viewModel.HeaderMessage.ValueChanged += UpdateHeaderText;
            
            _viewModel.IsTabCenterMessageActive.ValueChanged += UpdateTabCenterMessageIsActive;
            _viewModel.TabCenterMessage.ValueChanged += UpdateTabCenterText;
        }

        private void UpdateHeaderMessageIsActive(bool isActive)
        {
            _headerTextContainer.SetActive(isActive);
        }

        private void UpdateHeaderText(ScreenMessageData messageData)
        {
            _headerText.text = messageData.Text;
            _headerText.color = messageData.Color;
        }
        
        private void UpdateTabCenterMessageIsActive(bool isActive)
        {
            _tabCenterTextContainer.SetActive(isActive);
        }

        private void UpdateTabCenterText(ScreenMessageData messageData)
        {
            _tabCenterText.text = messageData.Text;
            _tabCenterText.color = messageData.Color;
        }
    }
}