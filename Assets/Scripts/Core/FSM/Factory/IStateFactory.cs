using Core.FSM.States;

namespace Core.FSM.Factory
{
    public interface IStateFactory
    {
        TState CreateState<TState>() where TState : IState;
    }
}