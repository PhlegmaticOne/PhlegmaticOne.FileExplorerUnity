using System;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Contracts;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers
{
    internal sealed class MonoContext : MonoBehaviour
    {
        [SerializeField] private MonoInstaller[] _installers;
        
        private readonly IDependencyContainer _container = new DependencyContainer();

        private IUpdateListener[] _updateListeners;

        public void Install(Action<IDependencyContainer> installAction = null)
        {
            foreach (var installer in _installers.AsSpan())
            {
                installer.Install(_container);
            }
            
            installAction?.Invoke(_container);
            _container.Inject();
            _updateListeners = _container.ResolveAll<IUpdateListener>();
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
        
        public void OnUpdate()
        {
            var deltaTime = Time.deltaTime;
            
            foreach (var updateListener in _updateListeners.AsSpan())
            {
                updateListener.OnUpdate(deltaTime);
            }
        }
    }
}