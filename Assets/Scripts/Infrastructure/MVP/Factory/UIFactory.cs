using Services.Save;
using UnityEngine;
using Zenject;

namespace Infrastructure.MVP.Factory
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private readonly ISaveService _saveService;

        public UIFactory(DiContainer container, ISaveService saveService)
        {
            _container = container;
            _saveService = saveService;
        }
        
        public TPresenter CreateWindow<TModel, TView, TPresenter, TShowParams>(string windowPath, Transform parent = null)
            where TModel : BaseModel, ISaveLoadable<TModel>
            where TView : BaseView<TModel>
            where TPresenter : BasePresenter<TView, TModel, TShowParams>, new()
            where TShowParams : class, IShowParams
        {
            TPresenter presenter = new TPresenter();
            _container.Inject(presenter);
            TModel model = _container.Resolve<TModel>();
            presenter.ConnectModel(model);
            TView view = Object.Instantiate(Resources.Load<TView>(windowPath), parent);
            _container.Inject(view);
            presenter.ConnectView(view);
            _saveService.TryLoad<TModel>(ref model);
            return presenter;
        }
    }
}