using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.Behaviours;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Services.LayoutUtils;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal sealed class ComponentHoldFileEntry : MonoBehaviour
    {
        [SerializeField] private ButtonHoldBehaviour _holdBehaviour;
        [SerializeField] private RectTransform _rectTransform;
        
        private FileEntryViewModel _viewModel;
        private IExplorerLayoutUtils _explorerLayoutUtils;

        public void Construct(
            IExplorerLayoutUtils explorerLayoutUtils, 
            ScrollRect scrollRect)
        {
            _explorerLayoutUtils = explorerLayoutUtils;
            _holdBehaviour.Construct(scrollRect);
        }

        public void Bind(FileEntryViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        public void Release()
        {
            Unsubscribe();
            _viewModel = null;
        }

        private void Subscribe()
        {
            _holdBehaviour.OnClicked += HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked += HoldBehaviourOnHoldClicked;
        }

        private void Unsubscribe()
        {
            _holdBehaviour.OnClicked -= HoldBehaviourOnClicked;
            _holdBehaviour.OnHoldClicked -= HoldBehaviourOnHoldClicked;
        }

        private void HoldBehaviourOnHoldClicked()
        {
            _viewModel.HoldClickCommand.ExecuteWithoutParameter();
        }

        private void HoldBehaviourOnClicked()
        {
            _viewModel.ClickCommand.Execute(CalculateViewPosition());
        }

        private ActionTargetViewPosition CalculateViewPosition()
        {
            return new ActionTargetViewPosition(
                _rectTransform.anchoredPosition,
                _rectTransform.rect.size,
                _explorerLayoutUtils.GetHeaderOffset());
        }
    }
}