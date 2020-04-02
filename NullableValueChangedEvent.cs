namespace HeavensBeat.Structs
{
    public class NullableValueChangedEvent<T> where T : struct
    {
        public readonly T? Old;
        public readonly T? New;

        public NullableValueChangedEvent(T? old, T? @new)
        {
            Old = old;
            New = @new;
        }
    }
}
