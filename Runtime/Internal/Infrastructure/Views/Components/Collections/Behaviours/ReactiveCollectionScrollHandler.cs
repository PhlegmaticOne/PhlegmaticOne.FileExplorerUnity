using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views.Scroll
{
    [Serializable]
    internal sealed class ReactiveCollectionScrollHandler : IReactiveCollectionBehaviour
    {
        [SerializeField] private ScrollRect _scroll;

        private readonly List<View> _children = new();
        
        private RectTransform _viewport;

        public void OnBind()
        {
            _viewport = _scroll.viewport;
            _scroll.onValueChanged.AddListener(UpdateChildren);
        }

        public void OnAdded(View view)
        {
            _children.Add(view);
        }

        public void OnRemoved(View view)
        {
            _children.Remove(view);
        }

        public void OnClear()
        {
            _children.Clear();
        }

        public void OnRelease()
        {
            _scroll.onValueChanged.RemoveListener(UpdateChildren);
        }

        private void UpdateChildren(Vector2 scrollPosition)
        {
            Span<Vector3> childCorners = stackalloc Vector3[4];

            Span<Vector3> viewportCorners = stackalloc Vector3[4];
            var viewportRect = _viewport.GetWorldCornersRectNonAlloc(viewportCorners);
            
            foreach (var child in _children)
            {
                var childRect = child.RectTransform.GetWorldCornersRectNonAlloc(childCorners);
                var isVisible = childRect.Overlaps(viewportRect);
                child.OnVisibleUpdate(isVisible);
            }
        }
    }
}