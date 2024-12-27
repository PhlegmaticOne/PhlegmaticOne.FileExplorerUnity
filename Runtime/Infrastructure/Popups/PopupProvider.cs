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
        private PopupView _currentPopup;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
        }
        
        public async Task Show<TPopup, TViewModel>(TViewModel viewModel) 
            where TPopup : PopupViewAsync<TViewModel>
            where TViewModel : PopupViewModel
        {
            var popup = _viewProvider.GetView<TPopup>().View;
            popup.transform.SetParent(_parent, false);
            _currentPopup = popup;
            _graphic.enabled = true;
            
            await popup.Show(viewModel);
            
            _viewProvider.ReleaseView(_currentPopup);
            _currentPopup = null;
            _graphic.enabled = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_currentPopup != null)
            {
                _currentPopup.Discard();
            }
        }
    }
}