using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

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
                Debug.LogException(e);
            }
        }
        
        public static async Task<byte[]> LoadContentAsync(this UnityWebRequest request, CancellationToken cancellationToken)
        {
            request.SendWebRequest();
            
            while (!request.isDone)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Yield();
            }

            var result = request.result == UnityWebRequest.Result.Success 
                ? request.downloadHandler.data 
                : Array.Empty<byte>();
            
            request.Dispose();

            return result;
        }
    }
}