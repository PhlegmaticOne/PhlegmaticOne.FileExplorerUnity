using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Behaviours
{
    internal sealed class ButtonHoldBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float _holdDuration;

        public event Action OnClicked;
        public event Action OnHoldClicked;

        private bool _isHoldingButton;
        private float _elapsedTime;

        public void OnPointerDown(PointerEventData eventData)
        {
            ToggleHoldingButton(true);
        }

        private void Update()
        {
            ManageButtonInteraction();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ManageButtonInteraction(true);
            ToggleHoldingButton(false);
        }

        private void ToggleHoldingButton(bool isPointerDown)
        {
            _isHoldingButton = isPointerDown;

            if (isPointerDown)
            {
                _elapsedTime = 0;
            }
        }

        private void ManageButtonInteraction(bool isPointerUp = false)
        {
            if (!_isHoldingButton)
            {
                return;
            }

            if (isPointerUp)
            {
                Click();
                return;
            }

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _holdDuration)
            {
                HoldClick();
            }
        }

        private void Click()
        {
            OnClicked?.Invoke();
        }

        private void HoldClick()
        {
            ToggleHoldingButton(false);
            OnHoldClicked?.Invoke();
        }
    }
}