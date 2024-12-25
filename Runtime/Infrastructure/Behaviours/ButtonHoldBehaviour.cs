using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Behaviours
{
    internal sealed class ButtonHoldBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private float _holdDuration = 0.5f;
        
        public event Action OnClicked;
        public event Action OnHoldClicked;

        private ScrollRect _scrollRect;
        private bool _isPointerDown;
        private float _holdTime;
        private bool _isLongPressInvoked;
        private bool _isDragging;

        public void Construct(ScrollRect scrollRect)
        {
            _scrollRect = scrollRect;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_scrollRect != null)
            {
                _scrollRect.OnDrag(eventData);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_scrollRect != null)
            {
                _scrollRect.OnBeginDrag(eventData);
            }
            
            _isDragging = true;
        }

        private void Update()
        {
            if (!_isPointerDown)
            {
                return;
            }
            
            _holdTime += Time.deltaTime;

            if (_holdTime < _holdDuration || _isDragging)
            {
                return;
            }
            
            OnHoldClicked?.Invoke();
            _isLongPressInvoked = true;
            ResetState();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_scrollRect != null)
            {
                _scrollRect.OnEndDrag(eventData);
            }
            
            _isDragging = false;
            ResetState();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isLongPressInvoked)
            {
                _isLongPressInvoked = false;
                _isPointerDown = false;
                return;
            }

            if(_isDragging)
            {
                return;
            }

            OnClicked?.Invoke();
            ResetState();
        }

        private void ResetState()
        {
            _isPointerDown = false;
            _holdTime = 0;
        }
    }
}