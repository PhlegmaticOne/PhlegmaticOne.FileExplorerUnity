using System;
using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels
{
    internal sealed class FileViewViewModel : PopupViewModel
    {
        private readonly FileEntryViewModel _viewModel;

        private Sprite _sprite;

        public FileViewViewModel(FileEntryViewModel viewModel, FileViewType viewType)
        {
            _viewModel = viewModel;
            ViewType = viewType;
        }

        public FileViewType ViewType { get; }

        public string Name => _viewModel.Name;
        
        public FileViewContent<Sprite> GetSprite()
        {
            try
            {
                var data = File.ReadAllBytes(_viewModel.Path);
                _sprite = data.CreateSpriteFromBytes();
                return FileViewContent<Sprite>.FromContent(_sprite);
            }
            catch (Exception e)
            {
                return FileViewContent<Sprite>.FromError(e);
            }
        }

        public FileViewContent<string> GetText()
        {
            try
            {
                var text = File.ReadAllText(_viewModel.Path);
                return FileViewContent<string>.FromContent(text);
            }
            catch (Exception e)
            {
                return FileViewContent<string>.FromError(e);
            }
        }

        public override void Release()
        {
            _sprite.Dispose();
        }
    }
}