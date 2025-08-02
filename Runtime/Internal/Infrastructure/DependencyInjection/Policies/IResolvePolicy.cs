using System;
using System.Reflection;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Policies
{
    internal interface IResolvePolicy
    {
        ParameterInfo[] GetInjectParameters(Type type);
        object CreateInstance(Type type);
        object CreateInstance(Type type, params object[] parameters);
        void Inject(object instance, object[] parameters);
    }
}