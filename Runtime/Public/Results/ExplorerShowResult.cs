namespace PhlegmaticOne.FileExplorer
{
    public readonly struct ExplorerShowResult
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
            SelectedFile = null;
        }

        public bool IsShowed { get; }
        public string SelectedFile { get; }
    }
}