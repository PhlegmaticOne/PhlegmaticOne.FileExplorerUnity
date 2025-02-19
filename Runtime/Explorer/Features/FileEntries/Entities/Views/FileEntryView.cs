using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Services.Scene;
using PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities
{
    internal sealed class FileEntryView : View
    {
        [SerializeField] private FileEntryIconView _iconView;
        [SerializeField] private ComponentText _fileName;
        [SerializeField] private ComponentActiveObject _activeObjectSelf;
        [SerializeField] private ComponentActiveObject _activeObjectSelection;
        [SerializeField] private ComponentHoldFileEntry _holdFileEntry;
        
        private FileEntryViewModel _viewModel;

        [ViewInject]
        public void Construct(
            FileEntryViewModel viewModel, 
            ISceneService sceneService, 
            ExplorerSceneObjects sceneObjects)
        {
            _holdFileEntry.Construct(sceneService, sceneObjects);
            _viewModel = viewModel;
        }
        
        protected override void OnInitializing()
        {
            _iconView.Setup(_viewModel.Icon);
            _fileName.Bind(_viewModel.Name);
            _activeObjectSelf.Bind(_viewModel.IsActive);
            _activeObjectSelection.Bind(_viewModel.IsSelected);
            _holdFileEntry.Bind(_viewModel);
        }

        public override void Release()
        {
            _iconView.Release();
            _fileName.Release();
            _activeObjectSelf.Release();
            _activeObjectSelection.Release();
            _holdFileEntry.Release();
            _viewModel = null;
        }
    }
}