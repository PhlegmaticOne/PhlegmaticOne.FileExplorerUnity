using System;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal abstract class FileContent
    {
        protected FileContent(string name, string errorMessage)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

        public string Name { get; }
        public string ErrorMessage { get; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
    
    internal class FileContent<T> : FileContent
    {
        public static FileContent<T> FromError(Exception exception) => new(default, null, exception.Message);
        public static FileContent<T> FromContent(T content, string name) => new(content, name, string.Empty);
        
        private FileContent(T content, string name, string error) : base(name, error)
        {
            Content = content;
        }

        public T Content { get; }
    }
}