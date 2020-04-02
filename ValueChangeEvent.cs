namespace HeavensBeat.Structs
{
    public class ValueChangeEvent<T>
    {
        public readonly T Old;
        public readonly T New;

        public ValueChangeEvent(T old, T @new)
        {
            Old = old;
            New = @new;
        }
    }
}
