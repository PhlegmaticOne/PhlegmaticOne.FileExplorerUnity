using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    [Serializable]
    internal sealed class ActionViewConfigData
    {
        [SerializeField] private string _key;
        [SerializeField] private string _description;
        [SerializeField] private ActionColorType _textColorType;
        [SerializeField] private Color _textColor;
        [SerializeField] private ActionColorType _backgroundColorType;
        [SerializeField] private Color _backgroundColor;

        public string Key => _key;
        public string Description => _description;
        public ActionColorType TextColorType => _textColorType;
        public Color TextColor => _textColor;
        public ActionColorType BackgroundColorType => _backgroundColorType;
        public Color BackgroundColor => _backgroundColor;
    }
}