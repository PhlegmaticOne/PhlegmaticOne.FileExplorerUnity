namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal readonly struct FileRenameResult
    {
        public FileRenameResult(string newName, bool willRename)
        {
            NewName = newName;
            WillRename = willRename;
        }

        public string NewName { get; }
        public bool WillRename { get; }
    }
}