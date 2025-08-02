using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal sealed class PopupProvider : MonoBehaviour, IPopupProvider, IPointerClickHandler
    {
        [SerializeField] private Graphic _graphic;
        [SerializeField] private Transform _parent;

        private IViewProvider _viewProvider;
        private Stack<IViewContainer<PopupView>> _activePopups;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
            _activePopups = new Stack<IViewContainer<PopupView>>();
        }
        
        public async Task Show<TPopup, TViewModel>(TViewModel viewModel) 
            where TPopup : PopupView<TViewModel>
            where TViewModel : PopupViewModel
        {
            var popup = _viewProvider.GetView<TPopup>(_parent, viewModel);
            _activePopups.Push(popup);
            _graphic.enabled = true;
            
            await popup.View.WaitClose();
            
            popup.Release();
            _graphic.enabled = _activePopups.Count > 0;
        }

        public void CloseLastPopup()
        {
            if (_activePopups.TryPop(out var popup))
            {
                popup.View.Close();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_activePopups.TryPop(out var popup))
            {
                popup.View.Discard();
            }
        }
    }
}