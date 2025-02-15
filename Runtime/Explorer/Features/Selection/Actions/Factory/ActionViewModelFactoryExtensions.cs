using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common.Factory;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions.Factory
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