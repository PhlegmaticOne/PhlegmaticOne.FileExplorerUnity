using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal sealed class ViewProvider : IViewProvider
    {
        private readonly IDependencyContainer _container;

        public ViewProvider(IDependencyContainer container)
        {
            _container = container;
        }
        
        public ViewContainer<T> GetView<T>(params object[] parameters) where T : View
        {
            var view = _container.Instantiate<T>(parameters);
            view.Initialize();
            return new ViewContainer<T>(view, this);
        }

        public void ReleaseView<T>(T view) where T : View
        {
            view.Release();
            Object.Destroy(view.gameObject);
        }
    }
}