using Core.UI;
using UnityEngine;
using Zenject;

namespace Core.Boot.Installer
{
    public sealed class BootInstaller : MonoInstaller
    {
        [SerializeField] private Bootstrapper _bootstrapper;
        [SerializeField] private UIRoot _uiRoot;
        
        public override void InstallBindings()
        {
            Container
                .Bind<Bootstrapper>()
                .FromInstance(_bootstrapper)
                .AsSingle().NonLazy();

            Container
                .Bind<UIRoot>()
                .FromInstance(_uiRoot)
                .AsSingle()
                .NonLazy();
        }

        public override void Start()
        {
            base.Start();
            _bootstrapper.Initialize();
        }
    }
}