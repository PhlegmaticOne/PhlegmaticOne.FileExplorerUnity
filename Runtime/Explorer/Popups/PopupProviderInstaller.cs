using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Popups.Errors;
using PhlegmaticOne.FileExplorer.Popups.FileView;
using PhlegmaticOne.FileExplorer.Popups.Properties;
using PhlegmaticOne.FileExplorer.Popups.Rename;
using PhlegmaticOne.FileExplorer.Popups.SelectAudio;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups
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
            BindPopups(container);
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

        private static void BindPopups(IDependencyContainer container)
        {
            BindAudioSelectPopup(container);
            BindErrorsPopup(container);
            BindFileViewPopup(container);
            BindPropertiesPopup(container);
            BindRenamePopup(container);
        }

        private static void BindAudioSelectPopup(IDependencyContainer container)
        {
            container.Register<ISelectAudioPopupProvider, SelectAudioPopupProvider>();
        }

        private static void BindErrorsPopup(IDependencyContainer container)
        {
            container.Register<IErrorPopupProvider, ErrorPopupProvider>();
        }

        private static void BindFileViewPopup(IDependencyContainer container)
        {
            container.Register<IFileAudioLoader, FileAudioLoader>();
            container.Register<IFileViewAudioProvider, FileViewAudioProvider>();
            
            container.Register<IFileTextLoader, FileTextLoader>();
            container.Register<IFileViewTextProvider, FileViewTextProvider>();
            
            container.Register<IFileImageLoader, FileImageLoader>();
            container.Register<IFileViewImageProvider, FileViewImageProvider>();
        }
        
        private static void BindPropertiesPopup(IDependencyContainer container)
        {
            container.Register<IPropertiesPopupProvider, PropertiesPopupProvider>();;
        }
        
        private static void BindRenamePopup(IDependencyContainer container)
        {
            container.Register<IFileRenamePopupProvider, FileRenamePopupProvider>();
        }
    }
}