using Infrastructure.MVP;
using Services.Save;
using UnityEngine;

namespace Core.UI
{
    public interface IUIController
    {
        void OpenWindow<TModel, TView, TPresenter, TShowParams>(string path, Transform parent, TShowParams showParams)
            where TModel : BaseModel, ISaveLoadable<TModel>
            where TView : BaseView<TModel>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel, TShowParams>, new();

        void Close<TPresenter>() where TPresenter : IPresenter; 
    }
}