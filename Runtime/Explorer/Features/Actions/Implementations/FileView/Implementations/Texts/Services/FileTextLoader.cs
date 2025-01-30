using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileTextLoader : IFileTextLoader
    {
        public async Task<FileViewContent<string>> GetText(FileEntryViewModel file, CancellationToken token)
        {
            try
            {
                var text = await File.ReadAllTextAsync(file.Path, token);
                return FileViewContent<string>.FromContent(text, file.Name);
            }
            catch (Exception e)
            {
                return FileViewContent<string>.FromError(e);
            }
        }
    }
}