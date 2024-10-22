using Core.FSM.States;

namespace Core.FSM
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
        void AddState<TState>(TState instance) where TState : IState;
    }
}