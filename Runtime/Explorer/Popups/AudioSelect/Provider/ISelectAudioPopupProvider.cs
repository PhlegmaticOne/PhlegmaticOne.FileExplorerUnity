using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Popups.AudioSelect
{
    internal interface ISelectAudioPopupProvider
    {
        Task<SelectAudioResult> SelectAudioType();
    }
}