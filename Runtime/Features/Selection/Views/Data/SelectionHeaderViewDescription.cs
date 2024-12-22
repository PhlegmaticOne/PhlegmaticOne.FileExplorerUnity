namespace PhlegmaticOne.FileExplorer.Features.Selection.Views.Data
{
    internal readonly struct SelectionHeaderViewDescription
    {
        private readonly int _totalCount;

        public SelectionHeaderViewDescription(int totalCount)
        {
            _totalCount = totalCount;
        }

        public string GetDescription()
        {
            if (_totalCount == 0)
            {
                return "Select entries";
            }
            
            var entriesWord = _totalCount == 1 ? "entry" : "entries";
            return $"Selected: {_totalCount} {entriesWord}";
        }
    }
}