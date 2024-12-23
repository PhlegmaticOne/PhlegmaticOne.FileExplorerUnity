using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels
{
    internal sealed class ScreenMessagesViewModel : ViewModel
    {
        public ScreenMessagesViewModel()
        {
            TabCenterMessage = new ReactiveProperty<ScreenMessageData>();
            IsTabCenterMessageActive = new ReactiveProperty<bool>(false);
            HeaderMessage = new ReactiveProperty<ScreenMessageData>();
            IsHeaderMessageActive = new ReactiveProperty<bool>(false);
        }
        
        public ReactiveProperty<bool> IsTabCenterMessageActive { get; }
        public ReactiveProperty<ScreenMessageData> TabCenterMessage { get; }
        public ReactiveProperty<bool> IsHeaderMessageActive { get; }
        public ReactiveProperty<ScreenMessageData> HeaderMessage { get; }
    }
}