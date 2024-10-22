using Core.FSM.Factory;
using Core.FSM.States;
using Zenject;

namespace Core.FSM.Installer
{
    public class ApplicationStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IStateMachine>()
                .To<ApplicationStateMachine>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<BootstrapState>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<LoadProgressState>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<CoreState>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
        }
    }
}