using System;

namespace Extensions.Property
{
    public class NotifyProperty<TProperty> : INotifyProperty<TProperty>
    {
        public event Action<TProperty> OnValueChanged;
        
        private TProperty _value;

        public TProperty Value
        {
            get => _value;
            set
            {
                if(_value.Equals(value)) return;
                
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
}