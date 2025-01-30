using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using UnityEngine;
using UnityEngine.Networking;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileAudioLoader : IFileAudioLoader
    {
        public async Task<FileViewContent<AudioClip>> LoadClip(
            FileEntryViewModel file, AudioType audioType, CancellationToken cancellationToken)
        {
            try
            {
                var url = GetFileUrl(file.Path);
                var request = UnityWebRequestMultimedia.GetAudioClip(url, audioType);
                request.SendWebRequest();

                while (!request.isDone)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Yield();
                }
                
                var handler = (DownloadHandlerAudioClip) request.downloadHandler;
                handler.streamAudio = true;
                return FileViewContent<AudioClip>.FromContent(handler.audioClip, file.Name);
            }
            catch (Exception e)
            {
                return FileViewContent<AudioClip>.FromError(e);
            }
        }

        private static string GetFileUrl(string audioClipFilePath)
        {
            return "file://" + audioClipFilePath;
        }
    }
}