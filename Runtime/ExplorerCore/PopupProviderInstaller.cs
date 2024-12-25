using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore
{
    internal sealed class PopupProviderInstaller : MonoInstaller
    {
        [SerializeField] private PopupProvider _popupProvider;
        [SerializeField] private PopupView[] _popupViews;
        [SerializeField] private View[] _viewPrefabs;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_popupProvider);

            foreach (var popupView in _popupViews)
            {
                container.RegisterPrefab(popupView);
            }

            foreach (var viewPrefab in _viewPrefabs)
            {
                container.RegisterPrefab(viewPrefab);
            }
        }
    }
}