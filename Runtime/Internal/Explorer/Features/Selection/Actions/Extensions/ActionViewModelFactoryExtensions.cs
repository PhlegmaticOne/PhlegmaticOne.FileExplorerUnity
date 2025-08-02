using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal static class ActionViewModelFactoryExtensions
    {
        public static ActionViewModel ClearSelection(this IActionViewModelFactory factory)
        {
            return factory.Create<ActionClearSelection>(SelectionActionKeys.ClearSelection);
        }
        
        public static ActionViewModel DeleteSelection(this IActionViewModelFactory factory)
        {
            return factory.Create<ActionDeleteSelection>(SelectionActionKeys.DeleteSelection);
        }
        
        public static ActionViewModel SelectAll(this IActionViewModelFactory factory)
        {
            return factory.Create<ActionSelectAll>(SelectionActionKeys.SelectAll);
        }
        
        public static ActionViewModel SelectionProperties(this IActionViewModelFactory factory)
        {
            return factory.Create<ActionSelectionProperties>(SelectionActionKeys.SelectionProperties);
        }
    }
}