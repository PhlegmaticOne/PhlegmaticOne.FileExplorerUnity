using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Actions.Views;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Actions
{
    internal sealed class ActionsInstaller : MonoInstaller
    {
        [SerializeField] private ActionsView _actionsView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_actionsView);
            container.Register<IActionViewPositionCalculator, ActionViewPositionCalculator>();
            container.Register<IFileViewContentProvider, FileViewContentProvider>();
            container.Register<IFilePropertiesViewProvider, FilePropertiesViewProvider>();
            container.Register<IFileRenameDataProvider, FileRenameDataProvider>();
            container.RegisterSelf<ActionsViewModel>();
        }
    }
}