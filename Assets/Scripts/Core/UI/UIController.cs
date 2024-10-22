using Infrastructure.MVP;
using Infrastructure.MVP.Factory;

namespace Core.UI
{
    public sealed class UIController : IUIController
    {
        private readonly IUIFactory _uiFactory;

        public UIController(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void OpenWindow<TModel, TView, TPresenter>() 
            where TModel : BaseModel
            where TView : BaseView<TModel>
            where TPresenter : BasePresenter<TView, TModel>, new()
        {
            TPresenter presenter = _uiFactory.CreateWindow<TModel, TView, TPresenter>(UIPath.CalculatorViewPath);
            presenter.Initialize();
            presenter.Show();
        }
    }
}