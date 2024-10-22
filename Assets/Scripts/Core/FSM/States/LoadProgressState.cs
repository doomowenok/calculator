namespace Core.FSM.States
{
    public sealed class LoadProgressState : IState
    {
        private readonly IStateMachine _stateMachine;

        public LoadProgressState(IStateMachine stateMachine)
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