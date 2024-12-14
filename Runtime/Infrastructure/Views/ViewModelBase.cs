namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    internal abstract class ViewModelBase
    {
        public bool IsDiscarded { get; private set; }

        public void Discard()
        {
            IsDiscarded = true;
        }
    }
}