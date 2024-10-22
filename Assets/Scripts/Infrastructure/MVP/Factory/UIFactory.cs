using UnityEngine;
using Zenject;

namespace Infrastructure.MVP.Factory
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;

        public UIFactory(DiContainer container)
        {
            _container = container;
        }
        
        public TPresenter CreateWindow<TModel, TView, TPresenter>(string windowPath, Transform parent = null)
            where TModel : BaseModel
            where TView : BaseView<TModel>
            where TPresenter : BasePresenter<TView, TModel>, new()
        {
            TPresenter presenter = new TPresenter();
            presenter.ConnectModel(_container.Resolve<TModel>());
            TView view = Object.Instantiate(Resources.Load<TView>(windowPath), parent);
            _container.Inject(view);
            presenter.ConnectView(view);
            return presenter;
        }
    }
}