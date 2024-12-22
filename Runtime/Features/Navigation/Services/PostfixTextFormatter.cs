using System;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services
{
    internal sealed class PostfixTextFormatter
    {
        private readonly string _text;
        private readonly char _postfixChar;

        public PostfixTextFormatter(string text, char postfixChar)
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