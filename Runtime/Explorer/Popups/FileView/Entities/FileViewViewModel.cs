using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewViewModel : PopupViewModel
    {
        private FileContent _content;
        
        public FileViewViewModel(IPopupProvider popupProvider) : base(popupProvider)
        {
            Name = new ReactiveProperty<string>();
        }

        public FileViewViewModel SetupAudio(FileContent<AudioClip> content) => Setup(content, FileContentType.Audio);
        public FileViewViewModel SetupImage(FileContent<Sprite> content) => Setup(content, FileContentType.Image);
        public FileViewViewModel SetupText(FileContent<string> content) => Setup(content, FileContentType.Text);

        public FileContentType ContentType { get; private set; }
        public ReactiveProperty<string> Name { get; }

        public bool HasError()
        {
            return _content.HasError;
        }

        public string GetErrorMessage()
        {
            return _content.ErrorMessage;
        }

        public FileContent<T> GetContent<T>()
        {
            return (FileContent<T>)_content;
        }

        private FileViewViewModel Setup(FileContent content, FileContentType contentType)
        {
            _content = content;
            ContentType = contentType;
            Name.SetValueNotify(content.Name);
            return this;
        }
    }
}