using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal sealed class PopupProvider : MonoBehaviour, IPopupProvider, IPointerClickHandler
    {
        [SerializeField] private Graphic _graphic;
        [SerializeField] private PopupsConfig _popupsConfig;
        [SerializeField] private Transform _parent;
        
        private PopupView _currentPopup;
        
        public async Task Show<TPopup, TViewModel>(TViewModel viewModel) 
            where TPopup : PopupViewAsync<TViewModel>
            where TViewModel : PopupViewModel
        {
            var popupPrefab = _popupsConfig.GetView<TPopup>();
            
            var popup = Instantiate(popupPrefab, _parent);
            _currentPopup = popup;
            _graphic.enabled = true;
            await popup.Show(viewModel);
            
            popup.Release();
            Destroy(popup.gameObject);
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