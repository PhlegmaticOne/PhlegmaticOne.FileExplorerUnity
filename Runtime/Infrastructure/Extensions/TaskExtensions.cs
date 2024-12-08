using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class TaskExtensions
    {
        public static async void Forget(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        public static async Task<byte[]> LoadContentAsync(this UnityWebRequest request)
        {
            request.SendWebRequest();
            
            while (!request.isDone)
            {
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