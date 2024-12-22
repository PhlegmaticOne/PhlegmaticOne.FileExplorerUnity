﻿using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common
{
    internal sealed class FileEntryActionRename : FileEntryAction
    {
        private readonly IFileRenameDataProvider _renameDataProvider;

        public FileEntryActionRename(
            IFileRenameDataProvider renameDataProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _renameDataProvider = renameDataProvider;
        }

        public override string Description => "Rename";

        public override FileEntryActionColor Color => FileEntryActionColor.Auto;

        protected override async Task<bool> ExecuteAction()
        {
            var renameData = await _renameDataProvider.GetRenameData(FileEntry);

            if (renameData.WillRename)
            {
                FileEntry.Rename(renameData.NewName);
            }

            return renameData.WillRename;
        }
    }
}