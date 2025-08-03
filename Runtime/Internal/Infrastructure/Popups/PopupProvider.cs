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
        private List<PopupEntry> _activePopups;

        [ViewInject]
        public void Construct(IViewProvider viewProvider)
        {
            _viewProvider = viewProvider;
            _activePopups = new List<PopupEntry>();
        }
        
        public async Task Show<TPopup, TViewModel>(TViewModel viewModel) 
            where TPopup : PopupView<TViewModel>
            where TViewModel : PopupViewModel
        {
            var popup = _viewProvider.GetView<TPopup>(_parent, viewModel);
            _activePopups.Add(new PopupEntry(popup, viewModel));
            _graphic.enabled = true;
            
            await popup.View.WaitClose();
            
            popup.Release();
            _graphic.enabled = _activePopups.Count > 0;
        }

        public void Close(PopupViewModel viewModel)
        {
            var entry = _activePopups.Find(x => x.ViewModel == viewModel);

            if (entry is not null)
            {
                _activePopups.Remove(entry);
                entry.GetView().Close();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_activePopups.Count == 0)
            {
                return;
            }
            
            var lastPopup = _activePopups[^1];
            _activePopups.RemoveAt(_activePopups.Count - 1);
            lastPopup.GetView().Discard();
        }
    }
}