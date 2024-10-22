using Core.UI;
using UnityEngine;

namespace Core.Features.Calculator.Factory
{
    public sealed class CalculatorElementFactory : ICalculatorElementFactory
    {
        public ResultView CreateResultView(Transform parent) => 
            Object.Instantiate(Resources.Load<ResultView>(UIPath.ResultViewPath), parent);
    }
}