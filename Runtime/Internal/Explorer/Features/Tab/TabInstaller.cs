using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Listeners;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab
{
    internal sealed class TabInstaller : MonoInstaller
    {
        [SerializeField] private TabView _tabView;
        [SerializeField] private ComponentCollectionFileEntries _tabCollectionView;
        [SerializeField] private FileEntryView _fileEntryViewPrefab;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_tabView);
            container.RegisterInstance(_tabCollectionView);
            
            container.RegisterPrefab(_fileEntryViewPrefab);
            
            container.RegisterInterfaces<TabEntriesAddedListener>();
            
            container.RegisterSelf<TabViewModel>();
            container.Register<IViewModelDisposable, TabViewModel>();
        }
    }
}