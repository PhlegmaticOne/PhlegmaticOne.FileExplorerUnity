using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Configs
{
    internal readonly struct ActionStaticViewData
    {
        public ActionStaticViewData(Color textColor, Color backgroundColor, string description)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;
            Description = description;
        }
        
        public Color TextColor { get; }
        public Color BackgroundColor { get; }
        public string Description { get; }
    }
}