namespace Fnx.Laws
{
    /// <summary>
    /// Contains two values of the same type that are expected to be equal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct IsEq<T>
    {
        private readonly T _x;
        private readonly T _y;

        public IsEq(T x, T y)
        {
            _x = x;
            _y = y;
        }

        public void Deconstruct(out T x, out T y)
        {
            x = _x;
            y = _y;
        }
    }

    public static class IsEq
    {
        public static IsEq<T> EqualUnderLaw<T>(T x, T y) => new IsEq<T>(x, y);
    }
}