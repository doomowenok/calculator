namespace Core.FSM.States
{
    public sealed class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;

        public BootstrapState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<CoreState>();
        }

        public void Exit()
        {
            
        }
    }
}