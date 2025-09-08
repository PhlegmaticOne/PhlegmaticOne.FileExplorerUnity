using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Lifecycle.Close;
using PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps;
using PhlegmaticOne.FileExplorer.Lifecycle.Show;
using PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Runtime.Explorer.States
{
    internal sealed class ExplorerLifecycleInstaller : MonoInstaller
    {
        [SerializeField] private ExplorerShowStepSceneViewSetup _stepSceneViewSetup;
        [SerializeField] private ExplorerCloseStepDestroyExplorerObject _stepDestroyExplorerObject;
        
        public override void Install(IDependencyContainer container)
        {
            BindShow(container);
            BindClose(container);
        }

        private void BindShow(IDependencyContainer container)
        {
#if UNITY_ANDROID
            container.Register<IExplorerShowStep, ExplorerShowStepRequestAndroidPermissions>();
#endif
            container.RegisterInstance(_stepSceneViewSetup);
            container.Register<IExplorerShowStep, ExplorerShowStepStaticViewBind>();
            container.Register<IExplorerShowStep, ExplorerShowStepStartActionListeners>();
            container.Register<IExplorerShowStep, ExplorerShowStepNavigateRoot>();
            
            container.Register<IExplorerShowCommand, ExplorerShowCommand>();
        }
        
        private void BindClose(IDependencyContainer container)
        {
            container.Register<IExplorerCloseStep, ExplorerCloseStepCancelOperations>();
            container.Register<IExplorerCloseStep, ExplorerCloseStepStopActionListeners>();
            container.Register<IExplorerCloseStep, ExplorerCloseStepDisposeIcons>();
            container.Register<IExplorerCloseStep, ExplorerCloseStepStaticViewsUnbind>();
            container.Register<IExplorerCloseStep, ExplorerCloseStepSetResult>();
            container.Register<IExplorerCloseStep, ExplorerCloseStepDisposeViewModels>();
            container.RegisterInstance(_stepDestroyExplorerObject);
            
            container.Register<IExplorerCloseCommand, ExplorerCloseCommand>();
        }
    }
}