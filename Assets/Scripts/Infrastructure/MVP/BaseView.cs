using UnityEngine;
using Zenject;

namespace Infrastructure.MVP
{
    public abstract class BaseView<TModel> : MonoBehaviour where TModel : BaseModel
    {
        protected TModel Model { get; private set; }
        
        [Inject]
        private void Construct(TModel model)
        {
            Model = model;
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}