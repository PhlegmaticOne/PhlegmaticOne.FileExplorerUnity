using System;

namespace PhlegmaticOne.FileExplorer.Infrastructure.TextFormatting
{
    internal sealed class TextFormatter
    {
        private readonly string _text;
        private readonly char _postfixChar;

        public TextFormatter(string text, char postfixChar)
        {
            _text = text;
            _postfixChar = postfixChar;
        }

        public string GetFormattedText(int postfixCharsCount)
        {
            return string.Create(_text.Length + postfixCharsCount, _text, (destination, source) =>
            {
                source.AsSpan().CopyTo(destination);
                destination[_text.Length..].Fill(_postfixChar);
            });
        }
    }
}