﻿using PhlegmaticOne.FileExplorer.Core.Searching.Services;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Searching
{
    internal sealed class SearchInstaller : MonoInstaller
    {
        [SerializeField] private SearchView _searchView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_searchView);
            container.Register<IFileEntryFinder, FileEntryFinder>();
            container.RegisterSelf<SearchViewModel>();
        }
    }
}