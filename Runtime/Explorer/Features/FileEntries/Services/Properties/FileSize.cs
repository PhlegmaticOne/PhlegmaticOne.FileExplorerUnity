using System.Collections.Generic;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Services.Proprties
{
    internal struct FileSize
    {
        private static readonly Dictionary<int, string> AvailableBytesPowMap = new()
        {
            { 1, "B" },
            { 2, "KB" },
            { 3, "MB" },
            { 4, "GB" }
        };
        
        private const int Bytes = 1024;

        public static FileSize Zero => new(0);
        
        public long Size { get; private set; }

        public FileSize(long size)
        {
            Size = size;
        }

        public string BuildBytesView()
        {
            return FormatSize(Size, "B");
        }

        public void Merge(FileSize size)
        {
            Size += size.Size;
        }

        public string BuildUnitView()
        {
            if (Size > 0)
            {
                foreach (var mapValue in AvailableBytesPowMap)
                {
                    if (Size < Mathf.Pow(Bytes, mapValue.Key))
                    {
                        return FormatSize(Size / Mathf.Pow(Bytes, mapValue.Key - 1), mapValue.Value);
                    }
                }
            }

            return BuildBytesView();
        }

        private static string FormatSize(float size, string point)
        {
            return $"{size:F} {point}";
        }
    }
}