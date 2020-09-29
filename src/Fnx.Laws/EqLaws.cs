using System;
using Fnx.Core.TypeClasses;

namespace Fnx.Laws
{
    public static class EqLaws<TEq, T>
        where TEq : struct, IEq<T>
    {
        public static bool Reflexivity(T x) => default(TEq).Eqv(x, x);

        public static bool Symmetry(T x, T y)
        {
            var eq = default(TEq);
            return eq.Eqv(x, y) == eq.Eqv(y, x);
        }

        public static bool Substitution(T x, T y, Func<T, T> f)
        {
            var eq = default(TEq);
            return eq.NEqv(x, y) || eq.Eqv(f(x), f(y));
        }

        public static bool Transitivity(T x, T y, T z)
        {
            var eq = default(TEq);
            return !(eq.Eqv(x, y) && eq.Eqv(y, z)) || eq.Eqv(x, z);
        }
    }
}