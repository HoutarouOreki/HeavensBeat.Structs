using System;

namespace HeavensBeat.Structs
{
    public class NullableLimitedValue<T> where T : struct, IComparable<T>
    {
        public T? Value
        {
            get => value.GetValueOrDefault();
            set
            {
                if (MaxValue.HasValue && MinValue.HasValue && MaxValue.Value.CompareTo(MinValue.Value) < 0)
                    throw new Exception("Max value is less than min value");
                if (value.HasValue)
                {
                    if (MinValue.HasValue && value.Value.CompareTo(MinValue.Value) < 0)
                        value = MinValue;
                    if (MaxValue.HasValue && value.Value.CompareTo(MaxValue.Value) > 0)
                        value = MaxValue;
                }
                this.value = value;
                var changeEvent = new NullableValueChangedEvent<T>(this.value, value);
                ValueChanged?.Invoke(changeEvent);
            }
        }

        public T? MaxValue
        {
            get => maxValue; set
            {
                maxValue = value;
                if (MaxValue.HasValue && Value.HasValue && Value.Value.CompareTo(MaxValue.Value) < 0)
                    Value = MaxValue;
            }
        }

        public T? MinValue
        {
            get => minValue; set
            {
                minValue = value;
                if (MinValue.HasValue && Value.HasValue && Value.Value.CompareTo(MinValue.Value) > 0)
                    Value = MinValue;
            }
        }

        public event Action<NullableValueChangedEvent<T>>? ValueChanged;

        private T? value;
        private T? maxValue;
        private T? minValue;
    }
}
