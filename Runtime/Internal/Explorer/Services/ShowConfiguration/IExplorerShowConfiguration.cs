namespace PhlegmaticOne.FileExplorer.Services.ShowConfiguration
{
    internal interface IExplorerShowConfiguration
    {
        bool IsInvestigateFiles();
        bool IsSelectSingleFile();
        bool IsSelectMultipleFiles();
        bool IsSupportedExtension(string extension);
    }
}