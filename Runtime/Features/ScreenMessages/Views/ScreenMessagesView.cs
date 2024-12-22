using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Views
{
    internal sealed class ScreenMessagesView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private GameObject _headerTextContainer;
        [SerializeField] private TextMeshProUGUI _headerText;

        [SerializeField] private GameObject _tabCenterTextContainer;
        [SerializeField] private TextMeshProUGUI _tabCenterText;
        
        private ScreenMessagesViewModel _viewModel;

        [ViewInject]
        public void Construct(ScreenMessagesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.IsHeaderMessageActive.ValueChanged += UpdateHeaderMessageIsActive;
            _viewModel.HeaderMessage.ValueChanged += UpdateHeaderText;
            
            _viewModel.IsTabCenterMessageActive.ValueChanged += UpdateTabCenterMessageIsActive;
            _viewModel.TabCenterMessage.ValueChanged += UpdateTabCenterText;
        }

        public void Unbind()
        {
            _viewModel.IsHeaderMessageActive.ValueChanged -= UpdateHeaderMessageIsActive;
            _viewModel.HeaderMessage.ValueChanged -= UpdateHeaderText;
            
            _viewModel.IsTabCenterMessageActive.ValueChanged -= UpdateTabCenterMessageIsActive;
            _viewModel.TabCenterMessage.ValueChanged -= UpdateTabCenterText;
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