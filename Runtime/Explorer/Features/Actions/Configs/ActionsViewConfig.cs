using System;
using System.Collections.Generic;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Configs
{
    [Serializable]
    internal sealed class ActionsViewConfig
    {
        private static int ItemsIndex;
        
        [SerializeField] private List<ActionViewConfigData> _actionsViewData;
        [SerializeField] private Color[] _backgroundAutoColors;
        [SerializeField] private Color _textAutoColor;
        
        public ActionStaticViewData GetViewData(string key)
        {
            var viewData = GetActionViewData(key);
            
            var backgroundColor = viewData.BackgroundColorType == ActionColorType.Custom 
                ? viewData.BackgroundColor 
                : GetBackgroundColor();
            
            var textColor = viewData.TextColorType == ActionColorType.Custom 
                ? viewData.TextColor 
                : _textAutoColor;

            return new ActionStaticViewData(textColor, backgroundColor, viewData.Description);
        }

        private ActionViewConfigData GetActionViewData(string actionKey)
        {
            var data = _actionsViewData.Find(x => x.Key.Equals(actionKey, StringComparison.OrdinalIgnoreCase));

            if (data is null)
            {
                throw new ArgumentException($"Action view config does not contain data for key: {actionKey}");
            }

            return data;
        }

        private Color GetBackgroundColor()
        {
            var currentColorIndex = ItemsIndex++ % _backgroundAutoColors.Length;
            return _backgroundAutoColors[currentColorIndex];
        }
    }
}