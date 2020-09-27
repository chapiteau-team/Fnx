using System.Collections.Generic;

namespace Fnx.Core.TypeClasses.Instances
{
    public struct DefaultEq<T> : IEq<T>
    {
        public bool Eqv(T a, T b) =>
            EqualityComparer<T>.Default.Equals(a, b);
    }
}