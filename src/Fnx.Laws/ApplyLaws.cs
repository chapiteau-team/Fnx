using System;
using Fnx.Core.Fn;
using Fnx.Core.TypeClasses;
using Fnx.Core.Types;
using static Fnx.Core.Prelude;

namespace Fnx.Laws
{
    public class ApplyLaws<TF>
    {
        private readonly IApply<TF> _apply;

        public ApplyLaws(IApply<TF> apply) => _apply = apply;

        public IsEq<IKind<TF, TC>> ApplyComposition<TA, TB, TC>(
            IKind<TF, TA> fa, IKind<TF, Func<TA, TB>> fab, IKind<TF, Func<TB, TC>> fbc)
        {
            var compose = Def<Func<TB, TC>, Func<Func<TA, TB>, Func<TA, TC>>>(bc => bc.Compose);

            return IsEq.EqualUnderLaw(
                _apply.Ap(fbc, _apply.Ap(fab, fa)),
                _apply.Ap(_apply.Ap(_apply.Map(fbc, compose), fab), fa));
        }

        public IsEq<IKind<TF, TC>> Map2ProductConsistency<TA, TB, TC>(
            IKind<TF, TA> fa, IKind<TF, TB> fb, Func<TA, TB, TC> f) =>
            IsEq.EqualUnderLaw(
                _apply.Map2(fa, fb, f),
                _apply.Map(_apply.Product(fa, fb), ((TA a, TB b) ab) => f(ab.a, ab.b)));

        public IsEq<IKind<TF, TA>> ProductLConsistency<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            IsEq.EqualUnderLaw(_apply.ProductL(fa, fb), _apply.Map2(fa, fb, (a, _) => a));

        public IsEq<IKind<TF, TB>> ProductRConsistency<TA, TB>(IKind<TF, TA> fa, IKind<TF, TB> fb) =>
            IsEq.EqualUnderLaw(_apply.ProductR(fa, fb), _apply.Map2(fa, fb, (_, b) => b));
    }
}