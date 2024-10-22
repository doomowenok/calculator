using Core.Features.Calculator;
using Core.UI;

namespace Core.FSM.States
{
    public sealed class CoreState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUIController _uiController;

        public CoreState(IStateMachine stateMachine, IUIController uiController)
        {
            _stateMachine = stateMachine;
            _uiController = uiController;
        }
        
        public void Enter()
        {
            _uiController.OpenWindow<CalculatorModel, CalculatorView, CalculatorPresenter>();
        }

        public void Exit()
        {
            
        }
    }
}