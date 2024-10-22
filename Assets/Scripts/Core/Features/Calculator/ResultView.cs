using TMPro;
using UnityEngine;

namespace Core.Features.Calculator
{
    public sealed class ResultView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _resultText;

        public void SetResult(string result)
        {
            _resultText.text = result;
        }
    }
}