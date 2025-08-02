namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers
{
    internal interface IInstaller
    {
        void Install(IDependencyContainer container);
    }
}