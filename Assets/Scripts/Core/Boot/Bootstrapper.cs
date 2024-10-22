using Core.FSM;
using Core.FSM.Factory;
using Core.FSM.States;
using UnityEngine;
using Zenject;

namespace Core.Boot
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        private void Construct(IStateMachine stateMachine, IStateFactory stateFactory)
        {
            _stateMachine = stateMachine; 
            _stateFactory = stateFactory;
        }

        public void Initialize()
        {
            _stateMachine.AddState(_stateFactory.CreateState<BootstrapState>());
            _stateMachine.AddState(_stateFactory.CreateState<CoreState>());

            _stateMachine.Enter<BootstrapState>();
        }
    }
}