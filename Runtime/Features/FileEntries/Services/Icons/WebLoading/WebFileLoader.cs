using System;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine.Networking;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.WebLoading
{
    internal sealed class WebFileLoader : IWebFileLoader
    {
        public async Task<WebLoadResult<byte[]>> LoadAsync(string url, CancellationToken cancellationToken)
        {
            var result = new WebLoadResult<byte[]>();
            
            try
            {
                var request = UnityWebRequest.Get(url);
                var content = await request.LoadContentAsync(cancellationToken);

                if (content.Length == 0)
                {
                    result.Error = request.error;
                }
                else
                {
                    result.Value = content;
                }
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }
            
            return result;
        }
    }
}