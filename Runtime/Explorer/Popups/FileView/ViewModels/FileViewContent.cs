using System;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal abstract class FileViewContent
    {
        protected FileViewContent(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
    
    internal class FileViewContent<T> : FileViewContent
    {
        public static FileViewContent<T> FromError(Exception exception) => new(default, null, exception.Message);
        public static FileViewContent<T> FromContent(T content, string name) => new(content, name, string.Empty);
        
        private FileViewContent(T content, string name, string error) : base(name)
        {
            Content = content;
            ErrorMessage = error;
        }

        public T Content { get; }
        public string ErrorMessage { get; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}