using System;

namespace HeavensBeat.Structs
{
    public class LimitedValue<T> : ILimitedValue where T : IComparable<T>
    {
        public T Value
        {
            get => value;
            set
            {
                if (MaxValue.CompareTo(MinValue) < 0)
                    throw new Exception("Max value is less than min value");
                if (value.CompareTo(MinValue) < 0)
                    value = MinValue;
                if (value.CompareTo(MaxValue) > 0)
                    value = MaxValue;
                this.value = value;
                var changeEvent = new ValueChangeEvent<T>(this.value, value);
                ValueChanged?.Invoke(changeEvent);
            }
        }

        public T MaxValue
        {
            get => maxValue; set
            {
                maxValue = value;
                if (Value.CompareTo(MaxValue) < 0)
                    Value = MaxValue;
            }
        }

        public T MinValue
        {
            get => minValue; set
            {
                minValue = value;
                if (Value.CompareTo(MinValue) > 0)
                    Value = MinValue;
            }
        }

        public event Action<ValueChangeEvent<T>>? ValueChanged;

        private T value;
        private T maxValue;
        private T minValue;

        public LimitedValue(T value, T minValue, T maxValue)
        {
            this.value = value;
            this.minValue = minValue;
            this.maxValue = maxValue;
            Value = value;
        }
    }
}
