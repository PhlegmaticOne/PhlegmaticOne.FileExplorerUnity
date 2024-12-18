namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal static class ReactivePropertyExtensions
    {
        public static void SmartSetValueNotify(this ReactiveProperty<bool> property, bool value)
        {
            switch (value)
            {
                case true when !property.Value:
                    property.SetValueNotify(true);
                    break;
                case false when property.Value:
                    property.SetValueNotify(false);
                    break;
            }
        }
    }
}