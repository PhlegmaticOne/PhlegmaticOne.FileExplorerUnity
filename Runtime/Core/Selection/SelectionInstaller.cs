using PhlegmaticOne.FileExplorer.Core.Selection.Services;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Selection
{
    internal sealed class SelectionInstaller : MonoInstaller
    {
        [SerializeField] private SelectionHeaderView _selectionHeaderView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_selectionHeaderView);
            container.Register<ISelectionActionsProvider, SelectionActionsProvider>();
            container.RegisterSelf<SelectionViewModel>();
        }
    }
}