using System;
using System.Collections.Generic;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public struct ListEq<T, TEq> : IEq<List<T>>
        where TEq : struct, IEq<T>
    {
        public bool Eqv(List<T> a, List<T> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            var eq = default(TEq);
            var count = a.Count;
            for (var i = 0; i < count; i++)
            {
                if (!eq.Eqv(a[i], b[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public struct ListEqK : IEqK<ListF>
    {
        public bool EqK<T, TEq>(IKind<ListF, T> x, IKind<ListF, T> y) where TEq : struct, IEq<T> =>
            default(ListEq<T, TEq>).Eqv(x.Fix(), y.Fix());
    }

    public struct ListInvariant : IInvariant<ListF>
    {
        public IKind<ListF, TB> XMap<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f, Func<TB, TA> g) =>
            fa.Fix().Map(f).ToKind();
    }

    public struct ListFunctor : IFunctor<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).ToKind();
    }

    public struct ListApply : IApply<ListF>
    {
        public IKind<ListF, TB> Map<TA, TB>(IKind<ListF, TA> fa, Func<TA, TB> f) =>
            fa.Fix().Map(f).ToKind();

        public IKind<ListF, TB> Ap<TA, TB>(IKind<ListF, Func<TA, TB>> ff, IKind<ListF, TA> fa) =>
            ff.Fix().FlatMap(fa.Fix().Map).ToKind();
    }
}