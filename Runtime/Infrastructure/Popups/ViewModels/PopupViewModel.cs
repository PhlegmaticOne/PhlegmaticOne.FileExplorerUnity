using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewModel : ViewModel
    {
        public bool IsDiscarded { get; private set; }

        public void Discard()
        {
            IsDiscarded = true;
        }
    }
}