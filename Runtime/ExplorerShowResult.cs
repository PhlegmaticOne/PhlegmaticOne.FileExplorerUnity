namespace PhlegmaticOne.FileExplorer
{
    public sealed class ExplorerShowResult
    {
        public static ExplorerShowResult Showed()
        {
            return new ExplorerShowResult(isShowed: true);
        }
        
        public static ExplorerShowResult NotShowed()
        {
            return new ExplorerShowResult(isShowed: false);
        }

        public ExplorerShowResult(bool isShowed)
        {
            IsShowed = isShowed;
        }

        public bool IsShowed { get; }
    }
}