namespace PhlegmaticOne.FileExplorer.Services.ShowConfiguration
{
    internal static class ExplorerShowConfigurationExtensions
    {
        public static bool IsSelectAnyFiles(this IExplorerShowConfiguration showConfiguration)
        {
            return showConfiguration.IsSelectSingleFile() || showConfiguration.IsSelectMultipleFiles();
        }
    }
}