using System;
using System.Collections.Generic;
using System.Reflection;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection
{
    internal sealed class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, object> _resolvedDependencies;
        private readonly Dictionary<Type, List<Type>> _contractToResolveTypesMap;
        
        public DependencyContainer()
        {
            _contractToResolveTypesMap = new Dictionary<Type, List<Type>>();
            _resolvedDependencies = new Dictionary<Type, object>();
            RegisterInstance(this);
        }

        public void Register(Type contractType, Type resolveType)
        {
            if (_contractToResolveTypesMap.TryGetValue(contractType, out var resolvedTypes))
            {
                resolvedTypes.Add(resolveType);
            }
            else
            {
                _contractToResolveTypesMap.Add(contractType, new List<Type> { resolveType });
            }
        }

        public void RegisterInstance(object instance)
        {
            var type = instance.GetType();
            this.RegisterInterfacesAndSelf(type);
            _resolvedDependencies.Add(type, instance);
        }

        public object Resolve(Type contractType)
        {
            var resolvedType = _contractToResolveTypesMap[contractType][0];
            return ResolvePrivate(resolvedType, Array.Empty<object>());
        }

        public Array ResolveAll(Type contractType)
        {
            var types = _contractToResolveTypesMap[contractType];
            var result = Array.CreateInstance(contractType, types.Count);

            for (var i = 0; i < types.Count; i++)
            {
                var resolvedType = types[i];
                result.SetValue(ResolvePrivate(resolvedType, Array.Empty<object>()), i);
            }

            return result;
        }

        public object Instantiate(Type type, params object[] parameters)
        {
            return InstantiatePrivate(type, parameters);
        }

        private object ResolvePrivate(Type type, object[] parameters)
        {
            if (_resolvedDependencies.TryGetValue(type, out var existing))
            {
                return existing;
            }

            var instance = InstantiatePrivate(type, parameters);
            _resolvedDependencies.TryAdd(type, instance);
            return instance;
        }

        private object InstantiatePrivate(Type type, object[] parameters)
        {
            var ctorParameters = type.GetConstructors()[0].GetParameters();

            if (ctorParameters.Length == 0)
            {
                return Activator.CreateInstance(type);
            }

            var resolved = ResolveParameters(ctorParameters, parameters);
            return Activator.CreateInstance(type, resolved);
        }

        private object[] ResolveParameters(IReadOnlyList<ParameterInfo> ctorParameters, object[] parameters)
        {
            var result = new object[ctorParameters.Count];
            var p = 0;

            for (var i = 0; i < ctorParameters.Count; i++)
            {
                var parameter = ctorParameters[i];

                if (parameters.Length > 0 && p < parameters.Length && parameter.ParameterType == parameters[p].GetType())
                {
                    result[i] = parameters[p++];
                }
                else if(!parameter.ParameterType.IsArray)
                {
                    result[i] = Resolve(parameter.ParameterType);
                }
                else
                {
                    result[i] = ResolveAll(parameter.ParameterType.GetElementType());
                }
            }

            return result;
        }
    }
}