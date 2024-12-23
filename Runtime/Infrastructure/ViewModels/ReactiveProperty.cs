using System;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveProperty<T> where T : IEquatable<T>
    {
        public event Action<T> ValueChanged;

        public ReactiveProperty() { }
        
        public ReactiveProperty(T value)
        {
            Value = value;
        }
        
        public T Value { get; private set; }

        public static implicit operator T(ReactiveProperty<T> property)
        {
            return property.Value;
        }

        public void SetValue(T value, bool notify)
        {
            if (notify)
            {
                SetValueNotify(value);
            }
            else
            {
                SetValueWithoutNotify(value);
            }
        }

        public void Raise()
        {
            OnPropertyChanged();
        }
        
        public void SetValueNotify(T value)
        {
            if (Value is not null && Value.Equals(value))
            {
                return;
            }
            
            Value = value;
            OnPropertyChanged();
        }

        public void SetValueWithoutNotify(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        private void OnPropertyChanged()
        {
            ValueChanged?.Invoke(Value);
        }
    }
}