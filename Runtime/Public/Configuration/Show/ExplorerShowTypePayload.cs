using System.Collections.Generic;
using System.Linq;

namespace PhlegmaticOne.FileExplorer
{
    public sealed class ExplorerShowTypePayload
    {
        public const string DirectoryExtension = "directory";
        
        public static ExplorerShowTypePayload InvestigateFiles()
        {
            return new ExplorerShowTypePayload(
                ExplorerShowType.InvestigateFiles, 
                new HashSet<string>());
        }

        public static ExplorerShowTypePayload SelectSingleFile(params string[] supportedExtensions)
        {
            return new ExplorerShowTypePayload(
                ExplorerShowType.SelectSingleFile, 
                supportedExtensions.ToHashSet());
        }
        
        public static ExplorerShowTypePayload SelectMultipleFiles(params string[] supportedExtensions)
        {
            return new ExplorerShowTypePayload(
                ExplorerShowType.SelectMultipleFiles, 
                supportedExtensions.ToHashSet());
        }
        
        private ExplorerShowTypePayload(
            ExplorerShowType showType, 
            HashSet<string> supportedExtensions)
        {
            ShowType = showType;
            SupportedExtensions = supportedExtensions;
        }
        
        public ExplorerShowType ShowType { get; }
        public HashSet<string> SupportedExtensions { get; }

        public bool IsSelectAnyFiles()
        {
            return ShowType is ExplorerShowType.SelectSingleFile or ExplorerShowType.SelectMultipleFiles;
        }
    }
}