using Core.UI;
using Infrastructure.MVP;
using Zenject;

namespace Core.Features.Info
{
    public sealed class InfoPresenter : BasePresenter<InfoView, InfoModel, InfoShowParams>
    {
        private IUIController _uiController;

        public InfoPresenter() { }

        [Inject]
        private void Construct(IUIController uiController)
        {
            _uiController = uiController;
        }
        
        public override void Initialize()
        {
            View.OkButton.onClick.AddListener(Close);
        }

        public void Dispose()
        {
            View.OkButton.onClick.RemoveListener(Close);
        }

        public override void Show(IShowParams showParams)
        {
            base.Show(showParams);
            View.UpdateMessageText(ShowParams.Message);
        }

        private void Close()
        {
            _uiController.Close<InfoPresenter>();
        }
    }
}