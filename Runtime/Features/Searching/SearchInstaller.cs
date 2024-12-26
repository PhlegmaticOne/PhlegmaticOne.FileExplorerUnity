using PhlegmaticOne.FileExplorer.Features.Searching.Services;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Searching
{
    internal sealed class SearchInstaller : MonoInstaller
    {
        [SerializeField] private SearchView _searchView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_searchView);
            container.Register<IFileEntrySearchFilter, FileEntrySearchFilter>();
            container.RegisterInterfacesAndSelf<SearchViewModel>();
        }
    }
}