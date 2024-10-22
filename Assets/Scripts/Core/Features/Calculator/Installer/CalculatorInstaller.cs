using System;
using Zenject;

namespace Core.Features.Calculator.Installer
{
    public class CalculatorInstaller : MonoInstaller  
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(CalculatorModel), typeof(IInitializable), typeof(IDisposable))
                .To<CalculatorModel>()
                .AsSingle()
                .Lazy();
        }
    }
}