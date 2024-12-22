using System;
using System.Linq;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection
{
    internal static class DependencyContainerExtensions
    {
        public static void Register<TContract, TResolved>(this IDependencyContainer container) 
            where TResolved : class, TContract where TContract : class
        {
            container.Register(typeof(TContract), typeof(TResolved));
        }

        public static void RegisterSelf<T>(this IDependencyContainer container) where T : class
        {
            RegisterSelf(container, typeof(T));
        }
        
        public static void RegisterInterfaces<T>(this IDependencyContainer container) where T : class
        {
            RegisterInterfaces(container, typeof(T));
        }

        public static void RegisterInterfacesAndSelf<T>(this IDependencyContainer container) where T : class
        {
            RegisterInterfacesAndSelf(container, typeof(T));
        }
        
        public static void RegisterInterfacesAndSelf(this IDependencyContainer container, Type type)
        {
            RegisterInterfaces(container, type);
            RegisterSelf(container, type);
        }

        public static void RegisterSelf(this IDependencyContainer container, Type type)
        {
            container.Register(type, type);
        }
        
        public static void RegisterInterfaces(this IDependencyContainer container, Type type)
        {
            foreach (var interfaceType in type.GetInterfaces())
            {
                if (interfaceType.Namespace!.StartsWith("UnityEngine"))
                {
                    continue;
                }
                
                container.Register(interfaceType, type);
            }
        }

        public static T Resolve<T>(this IDependencyContainer container) where T : class
        {
            return (T)container.Resolve(typeof(T));
        }
        
        public static T[] ResolveAll<T>(this IDependencyContainer container) where T : class
        {
            return container.ResolveAll(typeof(T)).OfType<T>().ToArray();
        }

        public static T Instantiate<T>(this IDependencyContainer container, params object[] parameters) where T : class
        {
            return (T)container.Instantiate(typeof(T), parameters);
        }
    }
}