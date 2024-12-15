using System;

namespace PhlegmaticOne.FileExplorer.Features.Actions.FileView.ViewModels
{
    internal readonly struct FileViewContent<T>
    {
        public static FileViewContent<T> FromError(Exception exception) => new(default, exception.Message);
        public static FileViewContent<T> FromContent(T content) => new(content, string.Empty);
        
        private FileViewContent(T content, string error)
        {
            Content = content;
            ErrorMessage = error;
        }

        public T Content { get; }
        public string ErrorMessage { get; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}