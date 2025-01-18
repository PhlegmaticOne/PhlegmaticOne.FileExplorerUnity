using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.States;
using PhlegmaticOne.FileExplorer.States.Commands;

namespace PhlegmaticOne.FileExplorer.Runtime.Explorer.States
{
    internal sealed class ExplorerStatesInstaller : IInstaller
    {
        public void Install(IDependencyContainer container)
        {
            container.Register<IExplorerCloseCommand, ExplorerCloseCommand>();
            container.Register<IExplorerShowCommand, ExplorerShowCommand>();
            
            container.Register<IExplorerStates, ExplorerStates>();
        }
    }
}