using System;
using Infrastructure.MVP;

namespace Core.Features.Calculator
{
    public sealed class CalculatorPresenter : BasePresenter<CalculatorView, CalculatorModel>, IDisposable
    {
        public override void Initialize()
        {
            View.InputField.onValueChanged.AddListener(UpdateField);
            View.SubmitButton.onClick.AddListener(Calculate);
        }

        public void Dispose()
        {
            View.InputField.onValueChanged.RemoveListener(UpdateField);
            View.SubmitButton.onClick.RemoveListener(Calculate);
        }

        private void UpdateField(string value)
        {
            Model.Field.Value = value;
        }

        private void Calculate()
        {
            Model.Calculate();
        }
    }
}