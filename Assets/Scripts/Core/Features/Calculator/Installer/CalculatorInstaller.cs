using Core.Features.Calculator.Factory;
using Zenject;

namespace Core.Features.Calculator.Installer
{
    public class CalculatorInstaller : MonoInstaller  
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CalculatorModel>()
                .ToSelf()
                .AsSingle()
                .Lazy();

            Container
                .Bind<ICalculatorElementFactory>()
                .To<CalculatorElementFactory>()
                .AsSingle()
                .Lazy();
        }
    }
}