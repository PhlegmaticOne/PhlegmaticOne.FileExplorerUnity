namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection
{
    internal interface IDependencyContainer
    {
        void Register<TBase, TImpl>() where TImpl : class, TBase where TBase : class;
        void Register<T>() where T : class;
        void RegisterInstance<T>(T instance) where T : class;
        T Resolve<T>() where T : class;
    }
}