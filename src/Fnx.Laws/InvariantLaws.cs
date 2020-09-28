using System;
using Fnx.Core;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public static class InvariantLaws<TInvariant, TF>
        where TInvariant : struct, IInvariant<TF>
    {
        public static IsEq<IKind<TF, TA>> InvariantIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(
                fa,
                default(TInvariant).XMap(fa, Combinators.I, Combinators.I));

        public static IsEq<IKind<TF, TC>> InvariantComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f1, Func<TB, TA> f2, Func<TB, TC> g1, Func<TC, TB> g2)
        {
            var invariant = default(TInvariant);
            var a = invariant.XMap(invariant.XMap(fa, f1, f2), g1, g2);
            var b = invariant.XMap(fa, g1.Compose(f1), f2.Compose(g2));
            return IsEq.EqualUnderLaw(a, b);
        }
    }
}