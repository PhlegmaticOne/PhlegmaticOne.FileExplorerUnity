using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels
{
    internal readonly struct ScreenMessageData
    {
        public ScreenMessageData(string text, Color color)
        {
            Text = text;
            Color = color;
        }

        public string Text { get; }
        public Color Color { get; }
    }
}