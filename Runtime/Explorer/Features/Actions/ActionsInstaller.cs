using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal sealed class ActionsInstaller : MonoInstaller
    {
        [SerializeField] private ActionsView _actionsView;
        [SerializeField] private ActionDropdownView _actionDropdown;
        [SerializeField] private ActionDropdownItemView _itemViewPrefab;
        [SerializeField] private ActionViewContainersData _containersData;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_actionsView);
            container.RegisterInstance(_containersData);
            container.RegisterInstance(_actionDropdown);
            
            container.RegisterPrefab(_itemViewPrefab);
            
            container.Register<IActionViewPositionCalculator, ActionViewPositionCalculator>();
            container.Register<IFilePropertiesViewProvider, FilePropertiesViewProvider>();
            container.Register<IFileRenameDataProvider, FileRenameDataProvider>();

            BindActionImplementations(container);
            
            container.RegisterSelf<ActionsViewModel>();
        }

        private static void BindActionImplementations(IDependencyContainer container)
        {
            BindAudioAction(container);
            BindImageAction(container);
            BindTextAction(container);
        }

        private static void BindAudioAction(IDependencyContainer container)
        {
            container.Register<IFileAudioLoader, FileAudioLoader>();
            container.Register<IFileViewAudioProvider, FileViewAudioProvider>();
            container.Register<ISelectAudioViewProvider, SelectAudioViewProvider>();
        }

        private static void BindTextAction(IDependencyContainer container)
        {
            container.Register<IFileTextLoader, FileTextLoader>();
            container.Register<IFileViewTextProvider, FileViewTextProvider>();
        }

        private static void BindImageAction(IDependencyContainer container)
        {
            container.Register<IFileImageLoader, FileImageLoader>();
            container.Register<IFileViewImageProvider, FileViewImageProvider>();
        }
    }
}