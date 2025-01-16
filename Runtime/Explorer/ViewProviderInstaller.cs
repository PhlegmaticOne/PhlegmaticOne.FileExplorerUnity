using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ViewProviderInstaller : MonoInstaller
    {
        private class ViewProviderSettings : IViewProviderSettings
        {
            private readonly ExplorerConfig _explorerConfig;

            public ViewProviderSettings(ExplorerConfig explorerConfig)
            {
                _explorerConfig = explorerConfig;
            }

            public TMP_FontAsset FontAsset => _explorerConfig.View.FontAsset;
        }
        
        public override void Install(IDependencyContainer container)
        {
            container.Register<IViewProvider, ViewProvider>();
            container.Register<IViewProviderSettings, ViewProviderSettings>();
        }
    }
}