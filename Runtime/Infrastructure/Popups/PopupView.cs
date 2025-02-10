using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupView : View
    {
        [SerializeField] private Button _closeButton;

        protected override void OnInitializing()
        {
            _closeButton.onClick.AddListener(Discard);
        }

        public abstract void Discard();

        public override void Release()
        {
            _closeButton.onClick.RemoveListener(Discard);
        }
    }
}