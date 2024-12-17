namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core
{
    internal struct FileSize
    {
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