namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class StringExtensions
    {
        public static string PathSlash(this string path)
        {
            return path.Replace("\\", "/");
        }
    }
}