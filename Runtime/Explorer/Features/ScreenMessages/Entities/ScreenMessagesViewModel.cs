using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Entities
{
    internal sealed class ScreenMessagesViewModel : ViewModel
    {
        public ScreenMessagesViewModel()
        {
            TabCenterMessage = new ReactiveProperty<string>();
            IsTabCenterMessageActive = new ReactiveProperty<bool>(false);
        }
        
        public ReactiveProperty<bool> IsTabCenterMessageActive { get; }
        public ReactiveProperty<string> TabCenterMessage { get; }
    }
}