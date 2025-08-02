using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class AssetExtensions
    {
        public static async Task<T> LoadFromResourcesAsync<T>(
            string path, CancellationToken token = default) where T : Object
        {
            var operation = Resources.LoadAsync<T>(path);

            while (!operation.isDone)
            {
                token.ThrowIfCancellationRequested();
                await Task.Yield();
            }

            return (T)operation.asset;
        }
        
        public static async Task<T> InstantiateAsync<T>(
            T asset, CancellationToken token = default) where T : Object
        {
            var instantiateOperation = Object.InstantiateAsync(asset);

            while (!instantiateOperation.isDone)
            {
                token.ThrowIfCancellationRequested();
                await Task.Yield();
            }

            return instantiateOperation.Result[0];
        }
    }
}