namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading
{
    internal sealed class WebLoadResult<T>
    {
        public T Value { get; set; }
        public string Error { get; set; }

        public bool HasError()
        {
            return !string.IsNullOrEmpty(Error);
        }
    }
}