using System;
using System.Collections.Generic;
using Core.FSM.States;

namespace Core.FSM
{
    public sealed class ApplicationStateMachine : IStateMachine
    {
        private readonly IDictionary<Type, IState> _states = new Dictionary<Type, IState>();
        
        private IState _activeState;

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }

        public void AddState<TState>(TState instance) where TState : IState
        {
            _states.Add(typeof(TState), instance);
        }
    }
}