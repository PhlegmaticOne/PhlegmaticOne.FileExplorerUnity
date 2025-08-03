using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal abstract class FileViewBase : View
    {
        [SerializeField] private FileViewConfig _viewConfig;
        
        protected FileViewViewModel ViewModel;

        [Inject]
        public void Construct(FileViewViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        
        public FileViewConfig ViewConfig => _viewConfig;
        
        public virtual void Resize(float size) { }
    }
}