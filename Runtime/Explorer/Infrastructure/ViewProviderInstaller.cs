using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;

namespace PhlegmaticOne.FileExplorer.Infrastructure
{
    internal sealed class ViewProviderInstaller : IInstaller
    {
        public void Install(IDependencyContainer container)
        {
            container.Register<IViewProvider, ViewProvider>();
            container.Register<IViewProviderSettings, ViewProviderSettings>();
        }

        private class ViewProviderSettings : IViewProviderSettings
        {
            private readonly ExplorerConfig _explorerConfig;

            public ViewProviderSettings(ExplorerConfig explorerConfig)
            {
                _explorerConfig = explorerConfig;
            }

            public TMP_FontAsset FontAsset => _explorerConfig.View.FontAsset;
        }
    }
}