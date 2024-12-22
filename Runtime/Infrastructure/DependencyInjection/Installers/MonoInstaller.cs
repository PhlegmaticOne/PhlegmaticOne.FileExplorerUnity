using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers
{
    internal abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void Install(IDependencyContainer container);
    }
}