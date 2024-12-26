using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Views
{
    internal sealed class ScreenMessagesView : MonoBehaviour, IExplorerViewComponent
    {
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
            _viewModel.IsTabCenterMessageActive.ValueChanged += UpdateTabCenterMessageIsActive;
            _viewModel.TabCenterMessage.ValueChanged += UpdateTabCenterText;
        }

        public void Unbind()
        {
            _viewModel.IsTabCenterMessageActive.ValueChanged -= UpdateTabCenterMessageIsActive;
            _viewModel.TabCenterMessage.ValueChanged -= UpdateTabCenterText;
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