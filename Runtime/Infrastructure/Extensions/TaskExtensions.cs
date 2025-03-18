using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class TaskExtensions
    {
        public static async void ForgetUnawareCancellation(this Task task)
        {
            try
            {
                await task;
            }
            catch (TaskCanceledException)
            {
                //ignore
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        
        public static async void Forget(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        
        public static async Task<byte[]> LoadContentAsync(
            this UnityWebRequest request, float timeout, CancellationToken cancellationToken)
        {
            var timeoutTimer = Stopwatch.StartNew();
            var timeoutSpan = TimeSpan.FromSeconds(timeout);
            
            request.SendWebRequest();
            
            while (!request.isDone && timeoutTimer.Elapsed < timeoutSpan)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Yield();
            }

            var result = request.result == UnityWebRequest.Result.Success 
                ? request.downloadHandler.data 
                : Array.Empty<byte>();
            
            request.Dispose();
            timeoutTimer.Stop();

            return result;
        }

        public static async Task<T> LoadFromResourcesAsync<T>(
            string path, CancellationToken token) where T : Object
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
            T asset, CancellationToken token) where T : Object
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