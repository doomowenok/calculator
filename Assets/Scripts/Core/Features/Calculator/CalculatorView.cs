using Infrastructure.MVP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Features.Calculator
{
    public sealed class CalculatorView : BaseView<CalculatorModel>
    {
        public TMP_InputField InputField;
        public Button SubmitButton;
        public Transform ResultContainer;
    }
}