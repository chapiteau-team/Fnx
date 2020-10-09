using System;
using Fnx.Core;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;

namespace Fnx.Laws
{
    public class InvariantLaws<TF>
    {
        private readonly IInvariant<TF> _invariant;

        public InvariantLaws(IInvariant<TF> invariant) => _invariant = invariant;

        public IsEq<IKind<TF, TA>> InvariantIdentity<TA>(IKind<TF, TA> fa) =>
            IsEq.EqualUnderLaw(
                fa,
                _invariant.XMap(fa, Combinators.I, Combinators.I));

        public IsEq<IKind<TF, TC>> InvariantComposition<TA, TB, TC>(
            IKind<TF, TA> fa, Func<TA, TB> f1, Func<TB, TA> f2, Func<TB, TC> g1, Func<TC, TB> g2)
        {
            var a = _invariant.XMap(_invariant.XMap(fa, f1, f2), g1, g2);
            var b = _invariant.XMap(fa, g1.Compose(f1), f2.Compose(g2));
            return IsEq.EqualUnderLaw(a, b);
        }
    }
}