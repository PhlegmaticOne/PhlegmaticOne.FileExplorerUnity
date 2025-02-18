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

        public void Setup(ActionViewData viewData)
        {
            _description.text = viewData.Description;
            _description.color = viewData.TextColor;
            _background.color = viewData.BackgroundColor;
        }
    }
}