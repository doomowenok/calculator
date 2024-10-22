namespace Infrastructure.MVP
{
    public abstract class BasePresenter<TView, TModel, TShowParams> : IPresenter 
        where TView : BaseView<TModel> 
        where TModel : BaseModel
        where TShowParams : class, IShowParams
    {
        protected TModel Model { get; private set; }
        protected TView View { get; private set; }
        protected TShowParams ShowParams { get; private set; }

        protected BasePresenter() { }

        public virtual void ConnectView(TView view)
        {
            View = view;
        }

        public virtual void DisconnectView()
        {
            View = null;
        }

        public virtual void ConnectModel(TModel model)
        {
            Model = model;
        }

        public virtual void DisconnectModel()
        {
            Model = null;
        }
        
        public virtual void Initialize() { }
        
        public virtual void Update()
        {
            Model.Update();
        }

        public virtual void Show(IShowParams showParams)
        {
            ShowParams = showParams as TShowParams;
            View.Show();
        }

        public virtual void Hide()
        {
            View.Hide();
        }
    }
}