namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class StringExtensions
    {
        public static string ToForwardSlash(this string path)
        {
            return path.Replace("\\", "/");
        }
    }
}