using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Popups.SelectAudio
{
    internal interface ISelectAudioPopupProvider
    {
        Task<SelectAudioResult> SelectAudioType();
    }
}