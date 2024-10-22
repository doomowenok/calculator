using System;
using System.Collections.Generic;
using Extensions.Property;
using Infrastructure.MVP;
using Services.Save;
using UnityEngine;
using Zenject;

namespace Core.Features.Calculator
{
    [Serializable]
    public sealed class CalculatorModel : BaseModel, IInitializable, IDisposable, ISaveLoadable<CalculatorModel>
    {
        public event Action<string, SubmitResultType> OnResultsChanged;
        
        private string _field = string.Empty;
        private List<string> _results = new List<string>();
        
        public INotifyProperty<string> Field { get; private set; } = new NotifyProperty<string>();

        void IInitializable.Initialize()
        {
            Field.OnValueChanged += UpdateField;
        }

        void IDisposable.Dispose()
        {
            Field.OnValueChanged -= UpdateField;
        }

        string ISaveLoadable<CalculatorModel>.PrepareForSave()
        {
            return JsonUtility.ToJson(this);
        }

        void ISaveLoadable<CalculatorModel>.Load(CalculatorModel data)
        {
            _field = data._field;
            Field.Value = data._field;

            _results = data._results;
        }

        private void UpdateField(string field)
        {
            _field = field;
        }

        public void Calculate()
        {
            // Calculation
            _results.Add(String.Empty);
            OnResultsChanged?.Invoke(_results[^1], SubmitResultType.Success);
        }
    }
}