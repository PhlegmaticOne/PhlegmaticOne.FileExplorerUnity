using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels
{
    internal sealed class FileViewViewModel : PopupViewModel
    {
        private readonly FileViewContent _content;

        public static FileViewViewModel Text(FileViewContent<string> textContent)
        {
            return new FileViewViewModel(textContent, FileViewType.Text);
        }

        public static FileViewViewModel Image(FileViewContent<Sprite> imageContent)
        {
            return new FileViewViewModel(imageContent, FileViewType.Image);
        }

        public static FileViewViewModel Audio(FileViewContent<AudioClip> audioContent)
        {
            return new FileViewViewModel(audioContent, FileViewType.Audio);
        }
        
        public FileViewViewModel(FileViewContent content, FileViewType viewType)
        {
            _content = content;
            ViewType = viewType;
        }

        public FileViewType ViewType { get; }
        public string Name => _content.Name;
        
        public FileViewContent<T> GetContent<T>()
        {
            return (FileViewContent<T>)_content;
        }
    }
}