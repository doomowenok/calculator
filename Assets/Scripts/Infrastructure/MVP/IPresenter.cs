namespace Infrastructure.MVP
{
    public interface IPresenter
    {
        void Initialize();
        void Update();
        void Show(IShowParams showParams);
        void Hide();
    }
}