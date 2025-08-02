namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands
{
    internal static class CommandExtensions
    {
        public static void ExecuteWithoutParameter(this ICommand command)
        {
            command.Execute(null);
        }
    }
}