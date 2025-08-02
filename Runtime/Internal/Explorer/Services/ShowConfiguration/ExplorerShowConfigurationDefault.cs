namespace PhlegmaticOne.FileExplorer.Services.ShowConfiguration
{
    internal sealed class ExplorerShowConfigurationDefault : IExplorerShowConfiguration
    {
        private readonly ExplorerShowTypePayload _showTypePayload;

        public ExplorerShowConfigurationDefault(
            ExplorerShowConfiguration showConfiguration)
        {
            _showTypePayload = showConfiguration.ShowTypePayload;
        }
        
        public bool IsInvestigateFiles()
        {
            return _showTypePayload.ShowType == ExplorerShowType.InvestigateFiles;
        }

        public bool IsSelectSingleFile()
        {
            return _showTypePayload.ShowType == ExplorerShowType.SelectSingleFile;
        }

        public bool IsSelectMultipleFiles()
        {
            return _showTypePayload.ShowType == ExplorerShowType.SelectMultipleFiles;
        }

        public bool IsSupportedExtension(string extension)
        {
            var extensions = _showTypePayload.SupportedExtensions;
            return extensions.Count == 0 || extensions.Contains(extension);
        }
    }
}