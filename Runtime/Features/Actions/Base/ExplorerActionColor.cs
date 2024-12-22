using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Base
{
    internal struct ExplorerActionColor
    {
        public static ExplorerActionColor Auto => new(Color.clear, Color.clear);

        public static ExplorerActionColor WithTextColor(Color color)
        {
            return new ExplorerActionColor(color, Color.clear);
        }

        public static ExplorerActionColor WithBackgroundColor(Color color)
        {
            return new ExplorerActionColor(Color.clear, color);
        }

        private ExplorerActionColor(Color textColor, Color backgroundColor)
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