using System;

namespace Extensions.Property
{
    public interface INotifyProperty<TProperty>
    {
        event Action<TProperty> OnValueChanged;
        TProperty Value { get; set; }
    }
}