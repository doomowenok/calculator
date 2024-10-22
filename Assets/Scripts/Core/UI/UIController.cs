using System;
using System.Collections.Generic;
using Infrastructure.MVP;
using Infrastructure.MVP.Factory;
using Services.Save;
using UnityEngine;

namespace Core.UI
{
    public sealed class UIController : IUIController
    {
        private readonly IUIFactory _uiFactory;
        
        private readonly IDictionary<Type, IPresenter> _presenters = new Dictionary<Type, IPresenter>();

        public UIController(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void OpenWindow<TModel, TView, TPresenter, TShowParams>(string path, Transform parent, TShowParams showParams)
            where TModel : BaseModel, ISaveLoadable<TModel>
            where TView : BaseView<TModel>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel, TShowParams>, new()
        {
            if (_presenters.TryGetValue(typeof(TPresenter), out IPresenter presenter))
            {
                presenter.Show(showParams);
                return;
            }

            presenter = _uiFactory.CreateWindow<TModel, TView, TPresenter, TShowParams>(path, parent);
            presenter.Initialize();
            presenter.Update();
            presenter.Show(showParams);
            _presenters.Add(typeof(TPresenter), presenter);
        }

        public void Close<TPresenter>() where TPresenter : IPresenter 
        {
            _presenters[typeof(TPresenter)].Hide();
        }
    }
}