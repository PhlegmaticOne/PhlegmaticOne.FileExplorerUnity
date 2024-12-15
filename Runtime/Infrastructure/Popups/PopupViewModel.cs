namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewModel
    {
        public bool IsDiscarded { get; private set; }

        public void Discard()
        {
            IsDiscarded = true;
        }

        public virtual void Release() { }
    }
}