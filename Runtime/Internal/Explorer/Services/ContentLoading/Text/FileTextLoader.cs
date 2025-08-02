using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal sealed class FileTextLoader : IFileTextLoader
    {
        public async Task<FileContent<string>> GetText(FileEntryViewModel file, CancellationToken token)
        {
            try
            {
                var text = await File.ReadAllTextAsync(file.Path, token);
                return FileContent<string>.FromContent(text, file.Name);
            }
            catch (Exception e)
            {
                return FileContent<string>.FromError(e);
            }
        }
    }
}