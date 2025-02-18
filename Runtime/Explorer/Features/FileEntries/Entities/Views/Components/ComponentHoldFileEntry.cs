using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Infrastructure.Behaviours;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Services.Scene;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal sealed class ComponentHoldFileEntry : MonoBehaviour
    {
        [SerializeField] private ButtonHoldBehaviour _holdBehaviour;
        [SerializeField] private RectTransform _rectTransform;
        
        private FileEntryViewModel _viewModel;
        private ISceneService _sceneService;

        public void Construct(ISceneService sceneService)
        {
            _sceneService = sceneService;
            _holdBehaviour.Construct(sceneService.ScrollRect);
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

        private FileEntryPosition CalculateViewPosition()
        {
            return new FileEntryPosition(
                _rectTransform.anchoredPosition,
                _rectTransform.rect.size,
                _sceneService.GetHeaderOffset());
        }
    }
}