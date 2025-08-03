using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Policies
{
    internal sealed class ResolvePolicyPrefab : IResolvePolicy
    {
        private readonly Dictionary<Type, MonoBehaviour> _prefabs;

        public ResolvePolicyPrefab(Dictionary<Type, MonoBehaviour> prefabs)
        {
            _prefabs = prefabs;
        }

        public ParameterInfo[] GetInjectParameters(Type type)
        {
            var injectMethod = GetInjectMethod(type);
            return injectMethod?.GetParameters() ?? Array.Empty<ParameterInfo>();
        }

        public object CreateInstance(Type type)
        {
            return Object.Instantiate(_prefabs[type]);
        }

        public object CreateInstance(Type type, params object[] parameters)
        {
            var instance = CreateInstance(type);
            var injectMethod = GetInjectMethod(type);

            if (injectMethod != null)
            {
                injectMethod.Invoke(instance, parameters);
            }

            return instance;
        }

        public void Inject(object instance, object[] parameters)
        {
            var injectMethod = GetInjectMethod(instance.GetType());

            if (injectMethod != null)
            {
                injectMethod.Invoke(instance, parameters);
            }
        }

        private static MethodInfo GetInjectMethod(Type type)
        {
            return type.GetMethods()
                .FirstOrDefault(x => x.GetCustomAttribute<InjectAttribute>() != null);
        }
    }
}