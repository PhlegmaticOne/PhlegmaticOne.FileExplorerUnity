using PhlegmaticOne.FileExplorer.Features.Selection.Services;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Selection
{
    internal sealed class SelectionInstaller : MonoInstaller
    {
        [SerializeField] private SelectionHeaderView _selectionHeaderView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_selectionHeaderView);
            container.Register<ISelectionActionsProvider, SelectionActionsProvider>();
            container.RegisterInterfacesAndSelf<SelectionViewModel>();
        }
    }
}