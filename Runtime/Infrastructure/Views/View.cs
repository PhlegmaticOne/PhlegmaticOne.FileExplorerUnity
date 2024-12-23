using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class View : MonoBehaviour
    {
        protected ViewModel ViewModel;
        
        public abstract void Initialize();
        public abstract void Release();

        public bool IsBindTo(ViewModel viewModel)
        {
            return ReferenceEquals(ViewModel, viewModel);
        }
    }
}