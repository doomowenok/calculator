using Services.Parser;
using Services.Save;
using Zenject;

namespace Core.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IExpressionParser>()
                .To<ExpressionParser>()
                .AsSingle()
                .Lazy();

            Container
                .Bind<ISaveService>()
                .To<JsonSaveService>()
                .AsSingle()
                .NonLazy();
        }
    }
}