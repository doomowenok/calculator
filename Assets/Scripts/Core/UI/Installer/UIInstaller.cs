using Infrastructure.MVP.Factory;
using UnityEngine;
using Zenject;

namespace Core.UI.Installer
{
    public sealed class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IUIController>()
                .To<UIController>()
                .AsSingle()
                .NonLazy();
        }
    }
}