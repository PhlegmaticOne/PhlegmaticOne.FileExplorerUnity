using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
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

        public void SetupAudio(FileViewContent<AudioClip> content) => Setup(content, FileViewType.Audio);
        public void SetupImage(FileViewContent<Sprite> content) => Setup(content, FileViewType.Image);
        public void SetupText(FileViewContent<string> content) => Setup(content, FileViewType.Text);

        public FileViewType ViewType { get; private set; }
        public ReactiveProperty<string> Name { get; }
        
        public FileViewContent<T> GetContent<T>()
        {
            return (FileViewContent<T>)_content;
        }

        private void Setup(FileViewContent content, FileViewType viewType)
        {
            _content = content;
            ViewType = viewType;
            Name.SetValueNotify(content.Name);
        }
    }
}