using UnityEngine;

namespace Core.Features.Calculator.Factory
{
    public interface ICalculatorElementFactory
    {
        ResultView CreateResultView(Transform parent);
    }
}