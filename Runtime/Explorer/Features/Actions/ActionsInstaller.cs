﻿using PhlegmaticOne.FileExplorer.Features.Actions.Configs;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal sealed class ActionsInstaller : MonoInstaller
    {
        [SerializeField] private ActionsView _actionsView;
        [SerializeField] private ComponentCollectionActions _actionDropdown;
        [SerializeField] private ActionDropdownItemView _itemViewPrefab;
        [SerializeField] private ActionViewContainersData _containersData;
        [SerializeField] private ActionsViewConfig _viewConfig;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_actionsView);
            container.RegisterInstance(_containersData);
            container.RegisterInstance(_actionDropdown);
            container.RegisterInstance(_viewConfig);
            
            container.RegisterPrefab(_itemViewPrefab);
            
            container.Register<IActionViewPositionCalculator, ActionViewPositionCalculator>();
            
            container.Register<IActionViewModelFactory, ActionViewModelFactory>();
            container.Register<IActionErrorHandler, ActionErrorHandler>();

            container.RegisterSelf<ActionsViewModel>();
        }
    }
}