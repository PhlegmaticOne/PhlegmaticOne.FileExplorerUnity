using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels
{
    internal struct ActionColor
    {
        public static ActionColor Auto => new(Color.clear, Color.clear);

        public static ActionColor WithTextColor(Color color)
        {
            return new ActionColor(color, Color.clear);
        }

        public static ActionColor WithBackgroundColor(Color color)
        {
            return new ActionColor(Color.clear, color);
        }

        private ActionColor(Color textColor, Color backgroundColor)
        {
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }
        
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }

        public bool HasTextColor()
        {
            return TextColor != Color.clear;
        }

        public bool HasBackgroundColor()
        {
            return BackgroundColor != Color.clear;
        }
    }
}