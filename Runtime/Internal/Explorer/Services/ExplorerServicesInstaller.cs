using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Runtime.Explorer.Services.Result;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using PhlegmaticOne.FileExplorer.Services.Internet;
using PhlegmaticOne.FileExplorer.Services.LayoutUtils;
using PhlegmaticOne.FileExplorer.Services.ShowConfiguration;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Services
{
    internal sealed class ExplorerServicesInstaller : MonoInstaller
    {
        [SerializeField] private RectTransform _headerTransform;
        [SerializeField] private VerticalLayoutGroup _safeZoneLayout;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(new ExplorerLayoutUtils(_headerTransform, _safeZoneLayout));

            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IInternetProvider, InternetProvider>();
            container.Register<IExplorerResultProvider, ExplorerResultProvider>();
            container.Register<IExplorerResultSetter, ExplorerResultSetter>();
            container.Register<IExplorerShowConfiguration, ShowConfiguration.ExplorerShowConfigurationDefault>();
            
            BindContentLoaders(container);
        }

        private static void BindContentLoaders(IDependencyContainer container)
        {
            container.Register<IFileAudioLoader, FileAudioLoader>();
            container.Register<IFileTextLoader, FileTextLoader>();
            container.Register<IFileImageLoader, FileImageLoader>();
        }
    }
}