using UnityEngine;

namespace Infrastructure.MVP.Factory
{
    public interface IUIFactory
    {
        TPresenter CreateWindow<TModel, TView, TPresenter>(string windowPath, Transform parent = null)
            where TModel : BaseModel
            where TView : BaseView<TModel>
            where TPresenter : BasePresenter<TView, TModel>, new();
    }
}