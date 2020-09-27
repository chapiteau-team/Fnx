using System;
using Fnx.Core.DataTypes;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses.Instances
{
    public struct OptionEq<T, TEq> : IEq<Option<T>>
        where TEq : struct, IEq<T>
    {
        public bool Eqv(Option<T> a, Option<T> b) =>
            a.IsSome
                ? b.IsSome && default(TEq).Eqv(a.Get(), b.Get())
                : !b.IsSome;
    }

    public struct OptionEqK : IEqK<OptionF>
    {
        public bool EqK<T, TEq>(IKind<OptionF, T> x, IKind<OptionF, T> y) where TEq : struct, IEq<T> =>
            default(OptionEq<T, TEq>).Eqv(x.Fix(), y.Fix());
    }

    public struct OptionFunctor : IFunctor<OptionF>
    {
        public IKind<OptionF, TB> Map<TA, TB>(IKind<OptionF, TA> fa, Func<TA, TB> map) =>
            fa.Fix().Map(map);
    }
}