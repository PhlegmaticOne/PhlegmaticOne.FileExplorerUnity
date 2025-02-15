using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Core
{
    internal readonly struct ScreenMessageData : IEquatable<ScreenMessageData>
    {
        public ScreenMessageData(string text, Color color)
        {
            Text = text;
            Color = color;
        }

        public string Text { get; }
        public Color Color { get; }

        public bool Equals(ScreenMessageData other)
        {
            return Text == other.Text && Color.Equals(other.Color);
        }

        public override bool Equals(object obj)
        {
            return obj is ScreenMessageData other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, Color);
        }
    }
}