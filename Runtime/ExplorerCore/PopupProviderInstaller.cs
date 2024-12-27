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
            BindProvider(container);
            BindPopupPrefabs(container);
            BindPopupPrefabViews(container);
        }

        private void BindProvider(IDependencyContainer container)
        {
            container.RegisterInstance(_popupProvider);
        }

        private void BindPopupPrefabs(IDependencyContainer container)
        {
            foreach (var popupView in _popupViews)
            {
                container.RegisterPrefab(popupView);
            }
        }

        private void BindPopupPrefabViews(IDependencyContainer container)
        {
            foreach (var viewPrefab in _viewPrefabs)
            {
                container.RegisterPrefab(viewPrefab);
            }
        }
    }
}