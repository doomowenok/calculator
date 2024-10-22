using Services.Save;
using UnityEngine;

namespace Infrastructure.MVP.Factory
{
    public interface IUIFactory
    {
        TPresenter CreateWindow<TModel, TView, TPresenter, TShowParams>(string windowPath, Transform parent = null)
            where TModel : BaseModel, ISaveLoadable<TModel>
            where TView : BaseView<TModel>
            where TPresenter : BasePresenter<TView, TModel, TShowParams>, new()
            where TShowParams : class, IShowParams;
    }
}