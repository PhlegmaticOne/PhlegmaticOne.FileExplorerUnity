using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal sealed class ViewProvider : IViewProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IViewProviderSettings _settings;

        public ViewProvider(IDependencyContainer container, IViewProviderSettings settings)
        {
            _container = container;
            _settings = settings;
        }
        
        public ViewContainer<T> GetView<T>(Transform parent, params object[] parameters) where T : View
        {
            var view = _container.Instantiate<T>(parameters);
            view.transform.SetParent(parent, false);
            view.Initialize(_settings.FontAsset);
            return new ViewContainer<T>(view, this);
        }

        public void ReleaseView<T>(T view) where T : View
        {
            if (view == null)
            {
                return;
            }
            
            view.Release();
            Object.Destroy(view.gameObject);
        }
    }
}