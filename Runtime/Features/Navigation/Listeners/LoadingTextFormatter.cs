using System;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Listeners
{
    internal sealed class LoadingTextFormatter
    {
        private readonly LoadingTextConfig _loadingTextConfig;

        public LoadingTextFormatter(LoadingTextConfig loadingTextConfig)
        {
            _loadingTextConfig = loadingTextConfig;
        }

        public string GetFormattedText(int postfixCharsCount)
        {
            var text = _loadingTextConfig.LoadingTextValue;
            
            return string.Create(text.Length + postfixCharsCount, text, (destination, source) =>
            {
                source.AsSpan().CopyTo(destination);
                destination[text.Length..].Fill('.');
            });
        }
    }
}