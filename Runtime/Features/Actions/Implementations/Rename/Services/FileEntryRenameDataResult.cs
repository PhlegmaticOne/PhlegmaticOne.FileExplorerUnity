namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename
{
    internal readonly struct FileEntryRenameDataResult
    {
        public FileEntryRenameDataResult(string newName, bool willRename)
        {
            NewName = newName;
            WillRename = willRename;
        }

        public string NewName { get; }
        public bool WillRename { get; }
    }
}