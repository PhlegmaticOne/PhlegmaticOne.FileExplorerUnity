using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal struct ActionViewData
    {
        public ActionViewData(Color textColor, Color backgroundColor, string description)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;
            Description = description;
        }
        
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public string Description { get; }
    }
}