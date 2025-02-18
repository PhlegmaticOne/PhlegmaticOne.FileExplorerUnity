using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal sealed class FileImageLoader : IFileImageLoader
    {
        public async Task<FileViewContent<Sprite>> GetImage(FileEntryViewModel file, CancellationToken token)
        {
            try
            {
                var data = await File.ReadAllBytesAsync(file.Path, token);
                var sprite = data.CreateSpriteFromBytes();
                return FileViewContent<Sprite>.FromContent(sprite, file.Name);
            }
            catch (Exception e)
            {
                return FileViewContent<Sprite>.FromError(e);
            }
        }
    }
}