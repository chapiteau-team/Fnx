using System.Collections.Generic;

namespace Fnx.Core.TypeClasses.Instances
{
    public class DefaultEq<T> : IEq<T>
    {
        public bool Eqv(T a, T b) =>
            EqualityComparer<T>.Default.Equals(a, b);
    }

    public static class Default<T>
    {
        private static readonly IEq<T> EqSingleton = new DefaultEq<T>();

        public static IEq<T> Eq() => EqSingleton;
    }
}