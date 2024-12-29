using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Policies;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection
{
    internal sealed class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, object> _resolvedDependencies;
        private readonly ObjectResolver _objectResolver;
        
        public DependencyContainer()
        {
            _resolvedDependencies = new Dictionary<Type, object>();
            _objectResolver = new ObjectResolver();
            RegisterInstance(this);
        }

        public void Register(Type contractType, Type resolveType)
        {
            _objectResolver.RegisterClass(contractType, resolveType);
        }

        public void RegisterPrefab(MonoBehaviour prefab)
        {
            _objectResolver.RegisterPrefab(prefab);
        }

        public void RegisterInstance(object instance)
        {
            var type = instance.GetType();
            this.RegisterInterfacesAndSelf(type);
            _resolvedDependencies.Add(type, instance);
        }

        public object Resolve(Type contractType)
        {
            var resolvedType = _objectResolver.GetResolvedTypes(contractType)[0];
            return ResolvePrivate(resolvedType, Array.Empty<object>());
        }

        public Array ResolveAll(Type contractType)
        {
            var types = _objectResolver.GetResolvedTypes(contractType);
            var result = Array.CreateInstance(contractType, types.Count);

            for (var i = 0; i < types.Count; i++)
            {
                var resolvedType = types[i];
                result.SetValue(ResolvePrivate(resolvedType, Array.Empty<object>()), i);
            }

            return result;
        }

        public void Inject()
        {
            foreach (var (resolveType, instance) in _resolvedDependencies.ToArray().AsSpan())
            {
                if (!_objectResolver.IsMono(resolveType))
                {
                    continue;
                }
                
                var resolver = _objectResolver.GetResolver(resolveType);
                var injectParameters = resolver.GetInjectParameters(resolveType);

                if (injectParameters.Length == 0)
                {
                    continue;
                }
                
                var parameters = ResolveParameters(injectParameters, Array.Empty<object>());
                resolver.Inject(instance, parameters);
            }
        }

        public object Instantiate(Type type, params object[] parameters)
        {
            return InstantiatePrivate(type, parameters);
        }

        private object ResolvePrivate(Type type, IReadOnlyList<object> parameters)
        {
            if (_resolvedDependencies.TryGetValue(type, out var existing))
            {
                return existing;
            }

            var instance = InstantiatePrivate(type, parameters);
            _resolvedDependencies.TryAdd(type, instance);
            return instance;
        }

        private object InstantiatePrivate(Type type, IReadOnlyList<object> parameters)
        {
            var resolvePolicy = _objectResolver.GetResolver(type);
            var injectParameters = resolvePolicy.GetInjectParameters(type);

            if (injectParameters.Length == 0)
            {
                return resolvePolicy.CreateInstance(type);
            }

            var resolved = ResolveParameters(injectParameters, parameters);
            return resolvePolicy.CreateInstance(type, resolved);
        }

        private object[] ResolveParameters(
            IReadOnlyList<ParameterInfo> injectParameters, IReadOnlyList<object> parameters)
        {
            var result = new object[injectParameters.Count];
            var p = 0;

            for (var i = 0; i < injectParameters.Count; i++)
            {
                var parameter = injectParameters[i];

                if (parameters.Count > 0 && p < parameters.Count &&
                    (parameters[p].GetType() == parameter.ParameterType || 
                     parameters[p].GetType().IsSubclassOf(parameter.ParameterType)))
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