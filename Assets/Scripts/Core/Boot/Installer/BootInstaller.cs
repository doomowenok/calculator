using UnityEngine;
using Zenject;

namespace Core.Boot.Installer
{
    public sealed class BootInstaller : MonoInstaller
    {
        [SerializeField] private Bootstrapper _bootstrapper;
        
        public override void InstallBindings()
        {
            Container
                .Bind<Bootstrapper>()
                .FromInstance(_bootstrapper)
                .AsSingle().NonLazy();
        }

        public override void Start()
        {
            base.Start();
            _bootstrapper.Initialize();
        }
    }
}