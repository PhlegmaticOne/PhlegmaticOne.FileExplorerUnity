using System;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    [Serializable]
    internal sealed class ActionColorSelector
    {
        [SerializeField] private Color[] _backgroundColors;
        [SerializeField] private Color _textColor;
        
        public ActionColor GetColor(int itemsCount, ActionViewModel action)
        {
            var resultColor = new ActionColor();
            var actionColor = action.Color;
            
            resultColor.BackgroundColor = actionColor.HasBackgroundColor() 
                ? actionColor.BackgroundColor 
                : GetBackgroundColor(itemsCount);

            resultColor.TextColor = actionColor.HasTextColor() ? actionColor.TextColor : _textColor;

            return resultColor;
        }

        private Color GetBackgroundColor(int itemsCount)
        {
            var currentColorIndex = itemsCount % _backgroundColors.Length;
            return _backgroundColors[currentColorIndex];
        }
    }
}