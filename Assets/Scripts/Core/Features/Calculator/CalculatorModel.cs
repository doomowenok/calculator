using System;
using System.Collections.Generic;
using Infrastructure.MVP;
using Newtonsoft.Json;
using Services.Parser;
using Services.Save;

namespace Core.Features.Calculator
{
    [Serializable]
    public sealed class CalculatorModel : BaseModel, ISaveLoadable<CalculatorModel>
    {
        private readonly IExpressionParser _expressionParser;
        private readonly ISaveService _saveService;
        public event Action<string, SubmitResultType> OnResultsChanged;
        
        public string lastField;
        
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
            lastField = data.lastField;
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
            lastField = field;
            _saveService.Save(this);
        }

        public void Calculate()
        {
            bool parseResult = _expressionParser.TryGetResult(lastField, out int result);
            SubmitResultType resultType = parseResult ? SubmitResultType.Success : SubmitResultType.Error;

            string final = resultType switch
            {
                SubmitResultType.Error => $"{lastField}=ERROR",
                SubmitResultType.Success => $"{lastField}={result}",
                _ => throw new ArgumentOutOfRangeException()
            };

            Results.Add(final);
            _saveService.Save(this);
            OnResultsChanged?.Invoke(Results[^1], resultType);
        }
    }
}