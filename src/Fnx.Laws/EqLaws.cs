using System;
using Fnx.Core.TypeClasses;

namespace Fnx.Laws
{
    public class EqLaws<T>
    {
        private readonly IEq<T> _eq;

        public EqLaws(IEq<T> eq) => _eq = eq;

        public bool Reflexivity(T x) =>
            _eq.Eqv(x, x);

        public bool Symmetry(T x, T y) =>
            _eq.Eqv(x, y) == _eq.Eqv(y, x);

        public bool Substitution(T x, T y, Func<T, T> f) =>
            _eq.NEqv(x, y) || _eq.Eqv(f(x), f(y));

        public bool Transitivity(T x, T y, T z) =>
            !(_eq.Eqv(x, y) && _eq.Eqv(y, z)) || _eq.Eqv(x, z);
    }
}