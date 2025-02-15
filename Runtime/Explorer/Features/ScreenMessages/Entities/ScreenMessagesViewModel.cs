using PhlegmaticOne.FileExplorer.Features.ScreenMessages.Core;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Entities
{
    internal sealed class ScreenMessagesViewModel : ViewModel
    {
        public ScreenMessagesViewModel()
        {
            TabCenterMessage = new ReactiveProperty<ScreenMessageData>();
            IsTabCenterMessageActive = new ReactiveProperty<bool>(false);
        }
        
        public ReactiveProperty<bool> IsTabCenterMessageActive { get; }
        public ReactiveProperty<ScreenMessageData> TabCenterMessage { get; }
    }
}