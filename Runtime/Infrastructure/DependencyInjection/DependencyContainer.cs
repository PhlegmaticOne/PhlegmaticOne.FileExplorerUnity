using System;
using System.Collections.Generic;
using System.Reflection;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection
{
    internal sealed class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, object> _dependencies;
        private readonly Dictionary<Type, Type> _registerTypes;
        
        public DependencyContainer()
        {
            _registerTypes = new Dictionary<Type, Type>();
            _dependencies = new Dictionary<Type, object>();
            RegisterInstance<IDependencyContainer>(this);
        }

        public void Register<TBase, TImpl>() where TImpl : class, TBase where TBase : class
        {
            _registerTypes.TryAdd(typeof(TBase), typeof(TImpl));
        }

        public void Register<T>() where T : class
        {
            Register<T, T>();
        }

        public void RegisterInstance<T>(T instance) where T : class
        {
            _dependencies.TryAdd(typeof(T), instance);
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (_dependencies.TryGetValue(type, out var existing))
            {
                return existing;
            }

            var registerType = _registerTypes[type];
            var parameters = registerType.GetConstructors()[0].GetParameters();
            
            var instance = parameters.Length == 0 
                ? Activator.CreateInstance(registerType) 
                : Activator.CreateInstance(registerType, ResolveParameters(parameters));
            
            _dependencies.TryAdd(type, instance);
            
            return instance;
        }

        private object[] ResolveParameters(IReadOnlyList<ParameterInfo> parameters)
        {
            var result = new object[parameters.Count];

            for (var i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];
                result[i] = Resolve(parameter.ParameterType);
            }

            return result;
        }
    }
}