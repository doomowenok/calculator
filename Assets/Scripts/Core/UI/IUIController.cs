using Infrastructure.MVP;

namespace Core.UI
{
    public interface IUIController
    {
        void OpenWindow<TModel, TView, TPresenter>() 
            where TModel : BaseModel
            where TView : BaseView<TModel>
            where TPresenter : BasePresenter<TView, TModel>, new();
    }
}