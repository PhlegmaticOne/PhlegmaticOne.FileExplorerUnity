﻿namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons
{
    internal sealed class WebLoadResult<T>
    {
        public T Value { get; set; }
        public string Error { get; set; }

        public bool HasError()
        {
            return !string.IsNullOrEmpty(Error);
        }
    }
}