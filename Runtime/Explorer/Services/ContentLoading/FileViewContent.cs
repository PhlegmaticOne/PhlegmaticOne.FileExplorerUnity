using System;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal abstract class FileViewContent
    {
        protected FileViewContent(string name, string errorMessage)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

        public string Name { get; }
        public string ErrorMessage { get; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
    
    internal class FileViewContent<T> : FileViewContent
    {
        public static FileViewContent<T> FromError(Exception exception) => new(default, null, exception.Message);
        public static FileViewContent<T> FromContent(T content, string name) => new(content, name, string.Empty);
        
        private FileViewContent(T content, string name, string error) : base(name, error)
        {
            Content = content;
        }

        public T Content { get; }
    }
}