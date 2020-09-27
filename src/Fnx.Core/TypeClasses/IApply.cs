using System;
using Fnx.Core.Types;

namespace Fnx.Core.TypeClasses
{
    public partial interface IApply<TF> : IFunctor<TF>
    {
        IKind<TF, TB> Ap<TA, TB>(IKind<TF, Func<TA, TB>> ff, IKind<TF, TA> fa);

        IKind<TF, TZ> Ap2<TA, TB, TZ>(IKind<TF, Func<TA, TB, TZ>> ff, IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Ap(Ap(Map<Func<TA, TB, TZ>, Func<TA, Func<TB, TZ>>>(ff, f => a => b => f(a, b)), fa), fb);

        IKind<TF, TA> ProductL<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Map2(fa, fb, (a, b) => a);

        IKind<TF, TB> ProductR<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Ap(Map<TA, Func<TB, TB>>(fa, _ => b => b), fb);

        IKind<TF, (TA, TB)> Product<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            Ap(Map<TA, Func<TB, (TA, TB)>>(fa, a => b => (a, b)), fb);

        IKind<TF, TZ> Map2<TA, TB, TZ>(IKind<TF, TA> fa, IKind<TF, TB> fb, Func<TA, TB, TZ> f) =>
            Map(Product(fa, fb), ((TA a, TB b) x) => f(x.a, x.b));
    }
}