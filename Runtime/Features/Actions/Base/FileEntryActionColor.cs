using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal struct FileEntryActionColor
    {
        public static FileEntryActionColor Empty => new(Color.clear, Color.clear);

        public static FileEntryActionColor WithTextColor(Color color)
        {
            return new FileEntryActionColor(color, Color.clear);
        }

        public static FileEntryActionColor WithBackgroundColor(Color color)
        {
            return new FileEntryActionColor(Color.clear, color);
        }

        private FileEntryActionColor(Color textColor, Color backgroundColor)
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