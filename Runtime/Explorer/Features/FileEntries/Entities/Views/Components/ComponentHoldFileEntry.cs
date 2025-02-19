using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.Behaviours;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Services.Scene;
using PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal sealed class ComponentHoldFileEntry : MonoBehaviour
    {
        [SerializeField] private ButtonHoldBehaviour _holdBehaviour;
        [SerializeField] private RectTransform _rectTransform;
        
        private FileEntryViewModel _viewModel;
        private ISceneService _sceneService;

        public void Construct(ISceneService sceneService, ExplorerSceneObjects sceneObjects)
        {
            _sceneService = sceneService;
            _holdBehaviour.Construct(sceneObjects.ScrollRect);
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
                _sceneService.GetHeaderOffset());
        }
    }
}