using Core.Features.Calculator;
using Core.UI;

namespace Core.FSM.States
{
    public sealed class CoreState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUIController _uiController;
        private readonly UIRoot _uiRoot;

        public CoreState(IStateMachine stateMachine, IUIController uiController, UIRoot uiRoot)
        {
            _stateMachine = stateMachine;
            _uiController = uiController;
            _uiRoot = uiRoot;
        }
        
        public void Enter()
        {
            _uiController.OpenWindow<CalculatorModel, CalculatorView, CalculatorPresenter, CalculatorShowParams>(
                    UIPath.CalculatorViewPath, _uiRoot.Container, new CalculatorShowParams());
        }

        public void Exit()
        {
            
        }
    }
}