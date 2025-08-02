using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services.Navigator;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services.EntriesGenerationPolicies
{
    internal sealed class FileEntriesGenerationPolicyBatch : IFileEntriesGenerationPolicy
    {
        private readonly IExplorerNavigator _navigator;
        private readonly ExplorerConfig _config;

        public FileEntriesGenerationPolicyBatch(
            IExplorerNavigator navigator,
            ExplorerConfig config)
        {
            _navigator = navigator;
            _config = config;
        }

        public async Task GenerateFileEntriesAtPath(string path, CancellationToken token, 
            Action<IReadOnlyCollection<FileEntryViewModel>> onEntriesGenerated)
        {
            var batchCount = _config.View.AddFileEntriesBatchCount;
            var batch = new List<FileEntryViewModel>(batchCount);
            
            await foreach (var fileEntry in _navigator.Navigate(path, token))
            {
                if (token.IsCancellationRequested) break;
                
                batch.Add(fileEntry);
                
                if (batch.Count == batchCount) OnBatchGenerated();
                
                await Task.Yield();

                if (token.IsCancellationRequested) break;
            }

            if (batch.Count > 0 && !token.IsCancellationRequested)
            {
                OnBatchGenerated();
                await Task.Yield();
            }

            return;

            void OnBatchGenerated()
            {
                onEntriesGenerated(batch);
                batch.Clear();
            }
        }
    }
}