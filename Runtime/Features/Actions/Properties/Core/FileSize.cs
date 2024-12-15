namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core
{
    internal readonly struct FileSize
    {
        private const int Bytes = 1024;
        
        public long Size { get; }

        public FileSize(long size)
        {
            Size = size;
        }

        public string BuildBytesView()
        {
            return FormatSize(Size, "B");
        }

        public string BuildUnitView()
        {
            if (Size < Bytes)
            {
                return BuildBytesView();
            }

            if (Size < Bytes * Bytes)
            {
                return FormatSize((float)Size / Bytes, "KB");
            }

            if (Size < Bytes * Bytes * Bytes)
            {
                return FormatSize((float)Size / (Bytes * Bytes), "MB");
            }

            return FormatSize((float)Size / (Bytes * Bytes * Bytes), "GB");
        }

        private static string FormatSize(float size, string point)
        {
            return $"{size:F} {point}";
        }
    }
}