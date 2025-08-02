using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Policies
{
    internal sealed class ObjectResolver
    {
        private readonly Dictionary<Type, List<Type>> _contractToResolveTypesMap;
        private readonly Dictionary<Type, MonoBehaviour> _prefabs;
        
        private readonly ResolvePolicyDefaultClass _resolvePolicyDefaultClass;
        private readonly ResolvePolicyPrefab _resolvePolicyPrefab;
        
        public ObjectResolver()
        {
            _prefabs = new Dictionary<Type, MonoBehaviour>();
            _contractToResolveTypesMap = new Dictionary<Type, List<Type>>();
            
            _resolvePolicyDefaultClass = new ResolvePolicyDefaultClass();
            _resolvePolicyPrefab = new ResolvePolicyPrefab(_prefabs);
        }

        public IResolvePolicy GetResolver(Type type)
        {
            return IsMono(type) ? _resolvePolicyPrefab : _resolvePolicyDefaultClass;
        }

        public bool IsMono(Type type)
        {
            return type.IsSubclassOf(typeof(MonoBehaviour));
        }

        public void RegisterPrefab(MonoBehaviour prefab)
        {
            _prefabs.TryAdd(prefab.GetType(), prefab);
        }

        public void RegisterClass(Type contractType, Type resolveType)
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

        public List<Type> GetResolvedTypes(Type contractType)
        {
            return _contractToResolveTypesMap[contractType];
        }
    }
}