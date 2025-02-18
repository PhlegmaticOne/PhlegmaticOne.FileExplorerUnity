using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewViewModel : PopupViewModel
    {
        private FileViewContent _content;
        
        public FileViewViewModel(IPopupProvider popupProvider) : base(popupProvider)
        {
            Name = new ReactiveProperty<string>();
        }

        public FileViewViewModel SetupAudio(FileViewContent<AudioClip> content) => Setup(content, FileViewType.Audio);
        public FileViewViewModel SetupImage(FileViewContent<Sprite> content) => Setup(content, FileViewType.Image);
        public FileViewViewModel SetupText(FileViewContent<string> content) => Setup(content, FileViewType.Text);

        public FileViewType ViewType { get; private set; }
        public ReactiveProperty<string> Name { get; }

        public bool HasError()
        {
            return _content.HasError;
        }

        public string GetErrorMessage()
        {
            return _content.ErrorMessage;
        }

        public FileViewContent<T> GetContent<T>()
        {
            return (FileViewContent<T>)_content;
        }

        private FileViewViewModel Setup(FileViewContent content, FileViewType viewType)
        {
            _content = content;
            ViewType = viewType;
            Name.SetValueNotify(content.Name);
            return this;
        }
    }
}