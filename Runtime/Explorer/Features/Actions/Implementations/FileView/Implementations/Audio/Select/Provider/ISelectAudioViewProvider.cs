using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal interface ISelectAudioViewProvider
    {
        Task<SelectAudioViewResult> SelectAudioType();
    }
}