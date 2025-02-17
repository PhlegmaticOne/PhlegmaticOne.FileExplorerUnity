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
        private Stack<PopupView> _activePopups;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
            _activePopups = new Stack<PopupView>();
        }
        
        public async Task Show<TPopup, TViewModel>(TViewModel viewModel) 
            where TPopup : PopupViewAsync<TViewModel>
            where TViewModel : PopupViewModel
        {
            var popup = _viewProvider.GetView<TPopup>(viewModel).View;
            popup.transform.SetParent(_parent, false);
            _activePopups.Push(popup);
            _graphic.enabled = true;
            
            await popup.Show();
            
            _viewProvider.ReleaseView(popup);
            _graphic.enabled = false;
        }

        public void CloseLastPopup()
        {
            if (_activePopups.TryPop(out var popupView))
            {
                popupView.Close();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_activePopups.TryPop(out var popupView))
            {
                popupView.Discard();
            }
        }
    }
}