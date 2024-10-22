using Infrastructure.MVP;
using TMPro;
using UnityEngine.UI;

namespace Core.Features.Info
{
    public sealed class InfoView : BaseView<InfoModel>
    {
        public TMP_Text MessageText;
        public Button OkButton;

        public void UpdateMessageText(string message)
        {
            MessageText.text = message;
        }
    }
}