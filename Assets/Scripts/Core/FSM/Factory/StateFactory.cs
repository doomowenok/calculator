using Core.FSM.States;
using Zenject;

namespace Core.FSM.Factory
{
    public sealed class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container)
        {
            _container = container;
        }
        
        public TState CreateState<TState>() where TState : IState => 
            _container.Resolve<TState>();
    }
}