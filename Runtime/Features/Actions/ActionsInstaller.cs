using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal sealed class ActionsInstaller : MonoInstaller
    {
        [SerializeField] private ActionsView _actionsView;
        [SerializeField] private ActionDropdownView _actionDropdown;
        [SerializeField] private ActionDropdownItemView _itemViewPrefab;
        [SerializeField] private ActionViewContainersData _containersData;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_actionsView);
            
            container.RegisterInstance(_containersData);
            container.RegisterInstance(_actionDropdown);
            
            container.RegisterPrefab(_itemViewPrefab);
            
            container.Register<IActionViewPositionCalculator, ActionViewPositionCalculator>();
            container.Register<IFileViewContentProvider, FileViewContentProvider>();
            container.Register<IFilePropertiesViewProvider, FilePropertiesViewProvider>();
            container.Register<IFileRenameDataProvider, FileRenameDataProvider>();
            
            container.RegisterSelf<ActionsViewModel>();
        }
    }
}