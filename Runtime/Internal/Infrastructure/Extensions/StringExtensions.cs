namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class StringExtensions
    {
        public static string ToForwardSlash(this string path)
        {
            var replaced = path.Replace('\\', '/');
            return replaced[^1] == '/' ? RemoveLastChar(replaced) : replaced;
        }

        private static string RemoveLastChar(string value)
        {
            return value.Remove(value.Length - 1);
        }
    }
}