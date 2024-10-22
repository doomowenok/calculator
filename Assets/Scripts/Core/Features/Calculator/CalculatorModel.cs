using System;
using System.Collections.Generic;
using Infrastructure.MVP;
using Newtonsoft.Json;
using Services.Parser;
using Services.Save;
using UnityEngine;

namespace Core.Features.Calculator
{
    [Serializable]
    public sealed class CalculatorModel : BaseModel, ISaveLoadable<CalculatorModel>
    {
        private readonly IExpressionParser _expressionParser;
        private readonly ISaveService _saveService;
        public event Action<string, SubmitResultType> OnResultsChanged;

        public string LastField;
        public List<string> Results { get; private set; } = new List<string>();

        public CalculatorModel(IExpressionParser expressionParser, ISaveService saveService)
        {
            _expressionParser = expressionParser;
            _saveService = saveService;
        }

        string ISaveLoadable<CalculatorModel>.PrepareForSave()
        {
            return JsonConvert.SerializeObject(this);
        }

        void ISaveLoadable<CalculatorModel>.Load(CalculatorModel data)
        {
            LastField = data.LastField;
            Debug.Log(data.LastField);
            Results = new List<string>(data.Results);
        }

        public override void Update()
        {
            foreach (string result in Results)
            {
                OnResultsChanged?.Invoke(result, SubmitResultType.Success);
            }
        }

        public void SetField(string field)
        {
            LastField = field;
            _saveService.Save(this);
        }

        public void Calculate()
        {
            bool parseResult = _expressionParser.TryGetResult(LastField, out int result);
            SubmitResultType resultType = parseResult ? SubmitResultType.Success : SubmitResultType.Error;

            string final = resultType switch
            {
                SubmitResultType.Error => $"{LastField}=ERROR",
                SubmitResultType.Success => $"{LastField}={result}",
                _ => throw new ArgumentOutOfRangeException()
            };

            Results.Add(final);
            OnResultsChanged?.Invoke(Results[^1], resultType);
        }
    }
}