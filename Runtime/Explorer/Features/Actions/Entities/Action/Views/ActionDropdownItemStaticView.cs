using PhlegmaticOne.FileExplorer.Features.Actions.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action
{
    internal sealed class ActionDropdownItemStaticView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _background;

        public void Setup(ActionStaticViewData staticViewData)
        {
            _description.text = staticViewData.Description;
            _description.color = staticViewData.TextColor;
            _background.color = staticViewData.BackgroundColor;
        }
    }
}