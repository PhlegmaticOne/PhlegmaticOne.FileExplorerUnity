using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    internal sealed class ActionDropdownView : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private ActionDropdownItemView _itemPrefab;

        [Header("View config")] 
        [SerializeField] private Color[] _backgroundColors;
        [SerializeField] private Color _textColor;
        
        private readonly List<ActionDropdownItemView> _dropdownItemViews = new();
        public Vector2 Size => (transform as RectTransform)!.rect.size;

        public void AddActions(IEnumerable<IExplorerAction> newActions)
        {
            foreach (var action in newActions)
            {
                var view = Instantiate(_itemPrefab, transform);
                view.Construct(action, GetColor(action));
                _dropdownItemViews.Add(view);
            }
        }

        public void Rebuild()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }

        public void SetPosition(Vector3 position)
        {
            (transform as RectTransform)!.anchoredPosition = position;
        }

        public void Clear()
        {
            foreach (var itemView in _dropdownItemViews)
            {
                itemView.Release();
                Destroy(itemView.gameObject);
            }
            
            _dropdownItemViews.Clear();
        }

        private ExplorerActionColor GetColor(IExplorerAction action)
        {
            var resultColor = new ExplorerActionColor();
            var actionColor = action.Color;
            
            resultColor.BackgroundColor = actionColor.HasBackgroundColor() 
                ? actionColor.BackgroundColor 
                : GetBackgroundColor();

            resultColor.TextColor = actionColor.HasTextColor() ? actionColor.TextColor : _textColor;

            return resultColor;
        }

        private Color GetBackgroundColor()
        {
            var currentColorIndex = _dropdownItemViews.Count % _backgroundColors.Length;
            return _backgroundColors[currentColorIndex];
        }
    }
}