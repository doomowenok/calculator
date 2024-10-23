using System;
using Core.Features.Calculator.Factory;
using Core.Features.Info;
using Core.UI;
using Infrastructure.MVP;
using Zenject;

namespace Core.Features.Calculator
{
    public sealed class CalculatorPresenter : 
        BasePresenter<CalculatorView, CalculatorModel, CalculatorShowParams>,
        IDisposable
    {
        private IUIController _uiController;
        private UIRoot _uiRoot;
        private ICalculatorElementFactory _calculatorElementFactory;

        public CalculatorPresenter() { }

        [Inject]
        private void Construct(IUIController uiController, UIRoot uiRoot, ICalculatorElementFactory calculatorElementFactory)
        {
            _uiController = uiController;
            _uiRoot = uiRoot;
            _calculatorElementFactory = calculatorElementFactory;
        }

        public override void Initialize()
        {
            View.InputField.onValueChanged.AddListener(UpdateField);
            View.SubmitButton.onClick.AddListener(Calculate);

            Model.OnResultsChanged += ProcessResult;
        }

        public void Dispose()
        {
            View.InputField.onValueChanged.RemoveListener(UpdateField);
            View.SubmitButton.onClick.RemoveListener(Calculate);
        }

        private void UpdateField(string value)
        {
            Model.SetField(value);
        }

        public override void Update()
        {
            base.Update();
            View.InputField.text = Model.lastField;
        }

        private void Calculate()
        {
            Model.Calculate();
        }

        private void ProcessResult(string result, SubmitResultType resultType)
        {
            if (resultType == SubmitResultType.Error)
            {
                _uiController.OpenWindow<InfoModel, InfoView, InfoPresenter, InfoShowParams>(
                    UIPath.InfoViewPath,
                    _uiRoot.Container,
                    new InfoShowParams("Please check the expression you just entered"));   
            }
            
            ResultView resultView = _calculatorElementFactory.CreateResultView(View.ResultContainer);
            resultView.SetResult(result);
            
            View.InputField.text = string.Empty;
        }
    }
}