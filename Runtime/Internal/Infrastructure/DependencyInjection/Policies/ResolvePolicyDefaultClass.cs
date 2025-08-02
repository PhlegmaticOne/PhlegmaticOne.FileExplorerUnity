using System;
using System.Reflection;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Policies
{
    internal sealed class ResolvePolicyDefaultClass : IResolvePolicy
    {
        public ParameterInfo[] GetInjectParameters(Type type)
        {
            return type.GetConstructors()[0].GetParameters();
        }

        public object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters);
        }

        public void Inject(object instance, object[] parameters) { }
    }
}