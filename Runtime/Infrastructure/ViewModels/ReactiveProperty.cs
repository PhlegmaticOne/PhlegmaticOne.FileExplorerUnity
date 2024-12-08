using System;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveProperty<T>
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

        public void SetValue(T value)
        {
            Value = value;
            OnPropertyChanged();
        }

        private void OnPropertyChanged()
        {
            ValueChanged?.Invoke(Value);
        }
    }
}