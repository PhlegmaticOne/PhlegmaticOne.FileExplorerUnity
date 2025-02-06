using PhlegmaticOne.FileExplorer.Features.FileEntries.Views;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab
{
    internal sealed class TabInstaller : MonoInstaller
    {
        [SerializeField] private TabView _tabView;
        [SerializeField] private TabCollectionView _tabCollectionView;
        [SerializeField] private FileEntryView _fileEntryViewPrefab;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_tabView);
            container.RegisterInstance(_tabCollectionView);
            
            container.RegisterPrefab(_fileEntryViewPrefab);
            
            container.RegisterInterfaces<TabEntriesAddedListener>();
            
            container.RegisterSelf<TabViewModel>();
        }
    }
}