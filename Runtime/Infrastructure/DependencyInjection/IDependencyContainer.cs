using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection
{
    internal interface IDependencyContainer
    {
        void Register(Type contractType, Type resolveType);
        void RegisterPrefab(MonoBehaviour prefab);
        void RegisterInstance(object instance);
        object Resolve(Type contractType);
        object Instantiate(Type type, params object[] parameters);
        Array ResolveAll(Type contractType);
        void Inject();
    }
}